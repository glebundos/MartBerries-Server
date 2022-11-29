using MartBerries_Server.Application.Commands;
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
    public class UpdateSupplierProductHandler : IRequestHandler<UpdateSupplierProductCommand, SupplierProduct>
    {
        private readonly ISupplierProductRepository _supplierProductRepo;

        public UpdateSupplierProductHandler(ISupplierProductRepository supplierProductRepo) => _supplierProductRepo = supplierProductRepo;

        public async Task<SupplierProduct> Handle(UpdateSupplierProductCommand request, CancellationToken cancellationToken)
        {
            var oldSupplierProduct = await _supplierProductRepo.GetByIdAsync(request.Id);

            if (oldSupplierProduct == null)
            {
                throw new InvalidCastException(nameof(request));
            }

            oldSupplierProduct.SupplierId = request.SupplierId;
            oldSupplierProduct.Name = request.Name;
            oldSupplierProduct.Price = request.Price;

            var newSupplierProduct = await _supplierProductRepo.UpdateAsync(oldSupplierProduct);
            return(newSupplierProduct);
        }
    }
}
