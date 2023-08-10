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

        private readonly IMoneyTransferRepository _moneyTransferRepo;

        public BuyProductHandler(IProductRepository productRepo, ISupplierProductRepository supplierProductRepo,
                                 IProductTransferRepository productTransferRepository, IMoneyTransferRepository moneyTransferRepository)
        {
            _productRepo = productRepo;
            _supplierProductRepo = supplierProductRepo;
            _productTransferRepo = productTransferRepository;
            _moneyTransferRepo = moneyTransferRepository;
        }

        public async Task<bool> Handle(BuyProductCommand request, CancellationToken cancellationToken)
        {
            var supplierProduct = await _supplierProductRepo.GetByIdAsync(request.Id);

            if (supplierProduct == null)
            {
                throw new Exception(message: "Supplier not found");
            }

            var oldProduct = await _productRepo.GetByNameAsync(supplierProduct.Name);

            if (oldProduct == null)
            {
                var product = SupplierProductMapper.Mapper.Map<Product>(supplierProduct);
                product.Amount = request.Amount;

                var newProduct = await _productRepo.AddAsync(product);

                if (newProduct != null)
                {
                    await CreateTransferNotes(newProduct, request.Amount, supplierProduct.Price);
                    return true;
                }

                return false;
            }

            oldProduct.Amount += request.Amount;
            oldProduct = await _productRepo.UpdateAsync(oldProduct);

            if (oldProduct != null)
            {
                await CreateTransferNotes(oldProduct, request.Amount, supplierProduct.Price);
                return true;
            }

            return false;

        }

        private async Task CreateTransferNotes(Product product, int orderedAmount, decimal price)
        {
            var productTransfer = new ProductTransfer 
            {
                TransferDateTime = DateTime.UtcNow,
                ProductId = product.Id,
                Amount = orderedAmount,
                TransferType = TransferTypes.Import
            };

            await _productTransferRepo.AddAsync(productTransfer);

            var moneyTransfer = new MoneyTransfer
            {
                TransferDateTime = DateTime.Now,
                TransactionType = MoneyTransfer.TransactionTypes.Expense,
                Amount = price * orderedAmount
            };

            await _moneyTransferRepo.AddAsync(moneyTransfer);
            return;
        }
    }
}
