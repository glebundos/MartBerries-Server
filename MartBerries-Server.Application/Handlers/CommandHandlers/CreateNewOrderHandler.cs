using MartBerries_Server.Application.Commands;
using MartBerries_Server.Application.Mappers;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Handlers.CommandHandlers
{
    public class CreateNewOrderHandler : IRequestHandler<CreateNewOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepo;

        private readonly IOrderedProductRepository _orderedProductRepo;

        public CreateNewOrderHandler(IOrderRepository orderRepo, IOrderedProductRepository orderedProductRepo)
        {
            _orderRepo = orderRepo;
            _orderedProductRepo = orderedProductRepo;
        }

        public async Task<Guid> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
        {
            var orderedProducts = OrderedProductMapper.Mapper.Map<List<OrderedProduct>>(request.OrderedProducts);
            var orderEntity = OrderMapper.Mapper.Map<Order>(request);
            if (orderEntity == null)
            {
                return Guid.Empty;
            }

            var createdId = (await _orderRepo.AddAsync(orderEntity)).Id;

            for (int i = 0; i < orderedProducts.Count; i++)
            {
                orderedProducts[i].OrderId = createdId;
            }

            await _orderedProductRepo.AddRangeAsync(orderedProducts);

            return createdId;
        }
    }
}
