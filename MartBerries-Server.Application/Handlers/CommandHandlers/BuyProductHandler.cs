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
using static MartBerries_Server.Core.Entities.ProductTransfer;

namespace MartBerries_Server.Application.Handlers.CommandHandlers
{
    public class BuyProductHandler : IRequestHandler<BuyProductCommand, bool>
    {
        private readonly IProductRepository _productRepo;

        private readonly ISupplierProductRepository _supplierProductRepo;

        private readonly IProductTransferRepository _productTransferRepo;

        public BuyProductHandler(IProductRepository productRepo, ISupplierProductRepository supplierProductRepo, IProductTransferRepository productTransferRepository)
        {
            _productRepo = productRepo;
            _supplierProductRepo = supplierProductRepo;
            _productTransferRepo = productTransferRepository;
        }

        public async Task<bool> Handle(BuyProductCommand request, CancellationToken cancellationToken)
        {
            var supplierProduct = await _supplierProductRepo.GetByIdAsync(request.Id);

            if (supplierProduct == null)
            {
                throw new ArgumentException();
            }

            var oldProduct = await _productRepo.GetByName(supplierProduct.Name);

            if (oldProduct == null)
            {
                var product = SupplierProductMapper.Mapper.Map<Product>(supplierProduct);
                product.Amount = request.Amount;

                var newProduct = await _productRepo.AddAsync(product);

                if (newProduct != null)
                {
                    await CreateProductTransferNote(newProduct, request.Amount);
                    return true;
                }

                return false;
            }

            oldProduct.Amount += request.Amount;
            oldProduct = await _productRepo.UpdateAsync(oldProduct);

            if (oldProduct != null)
            {
                await CreateProductTransferNote(oldProduct, request.Amount);
                return true;
            }

            return false;

        }

        private async Task CreateProductTransferNote(Product product, int orderedAmount)
        {
            var productTransfer = new ProductTransfer 
            {
                TransferDateTime = DateTime.UtcNow,
                ProductId = product.Id,
                Amount = orderedAmount,
                TransferType = TransferTypes.Import
            };

            await _productTransferRepo.AddAsync(productTransfer);
            return;
        }
    }
}
