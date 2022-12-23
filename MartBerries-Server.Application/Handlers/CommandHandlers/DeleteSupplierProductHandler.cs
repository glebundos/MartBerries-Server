using MartBerries_Server.Application.Commands;
using MartBerries_Server.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Handlers.CommandHandlers
{
    public class DeleteSupplierProductHandler : IRequestHandler<DeleteSupplierProductCommand, Guid>
    {
        private readonly ISupplierProductRepository _supplierProductRepo;

        public DeleteSupplierProductHandler(ISupplierProductRepository supplierProductRepo) => _supplierProductRepo = supplierProductRepo;

        public async Task<Guid> Handle(DeleteSupplierProductCommand request, CancellationToken cancellationToken)
        {
            var supplierProduct = await _supplierProductRepo.GetByIdAsync(request.Id);

            if (supplierProduct == null)
            {
                throw new Exception(message: "Supplier product not found");
            }

            await _supplierProductRepo.DeleteAsync(supplierProduct);

            return supplierProduct.Id;
        }
    }
}
