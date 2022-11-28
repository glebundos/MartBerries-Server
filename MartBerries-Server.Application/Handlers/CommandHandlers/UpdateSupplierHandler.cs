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
    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierCommand, Supplier>
    {
        private readonly ISupplierRepository _supplierRepo;

        public UpdateSupplierHandler(ISupplierRepository supplierRepo) => _supplierRepo = supplierRepo;

        public async Task<Supplier> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var oldSupplier = await _supplierRepo.GetByIdAsync(request.Id);

            if (oldSupplier == null)
            {
                return null!;
            }

            oldSupplier.Name = request.Name;
            var newSupplier = await _supplierRepo.UpdateAsync(oldSupplier);
            return newSupplier;
        }
    }
}
