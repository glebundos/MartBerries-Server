using MartBerries_Server.Application.Commands;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MartBerries_Server.Core.Entities.Order;

namespace MartBerries_Server.Application.Handlers.CommandHandlers
{
    public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommand, Order>
    {
        private readonly IOrderRepository _orderRepo;

        private readonly IProductRepository _productRepo;

        private readonly IProductTransferRepository _productTransferRepo;

        public UpdateOrderStatusHandler(IOrderRepository orderRepository, IProductRepository productRepository, IProductTransferRepository productTransferRepository)
        {
            _orderRepo = orderRepository;
            _productRepo = productRepository;
            _productTransferRepo = productTransferRepository;
        }

        public async Task<Order> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var oldOrder = await _orderRepo.GetByIdAsync(request.Id);

            if (oldOrder == null)
            {
                throw new InvalidCastException(nameof(request));
            }

            if (request.StatusId == (int)OrderStatuses.InDelivery)
            {
                await CreateProductTransferNotes(request);
            }

            oldOrder.OrderStatusId = request.StatusId;
            var newOrder = await _orderRepo.UpdateAsync(oldOrder);
            return newOrder;
        }

        private async Task CreateProductTransferNotes(UpdateOrderStatusCommand request)
        {
            var orderedProducts = (await _orderRepo.GetByIdAsync(request.Id)).Products.ToList();
            var products = orderedProducts.Select(x => x.Product).ToList();
            var productIds = products.Select(x => x.Id).ToList();
            var productAmounts = products.Select(x => x.Amount).ToList();

            var productTransfers = new List<ProductTransfer>();
            for (int i = 0; i < products.Count(); i++)
            {
                productTransfers.Add(new ProductTransfer
                {
                    TransferDateTime = DateTime.UtcNow,
                    ProductId = productIds[i],
                    Amount = productAmounts[i],
                    TransferType = ProductTransfer.TransferTypes.Export
                });

                products[i].Amount -= orderedProducts[i].Amount;
                await _productRepo.UpdateAsync(products[i]);
            }

            await _productTransferRepo.AddRangeAsync(productTransfers);
            return;
        }
    }
}
