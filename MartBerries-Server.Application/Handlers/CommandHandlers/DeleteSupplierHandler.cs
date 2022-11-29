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
    public class DeleteSupplierHandler : IRequestHandler<DeleteSupplierCommand, Guid>
    {
        private readonly ISupplierRepository _supplierRepo;

        public DeleteSupplierHandler(ISupplierRepository supplierRepo) => _supplierRepo = supplierRepo;

        public async Task<Guid> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepo.GetByIdAsync(request.Id);

            if (supplier == null)
            {
                throw new KeyNotFoundException();
            }

            await _supplierRepo.DeleteAsync(supplier);
            return supplier.Id;
        }
    }
}
