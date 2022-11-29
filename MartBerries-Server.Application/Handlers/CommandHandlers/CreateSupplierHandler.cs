using MartBerries_Server.Application.Commands;
using MartBerries_Server.Application.Mappers;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Handlers.CommandHandlers
{
    internal class CreateSupplierHandler : IRequestHandler<CreateSupplierCommand, Guid>
    {
        private readonly ISupplierRepository _supplierRepository;

        public CreateSupplierHandler(ISupplierRepository supplierRepository) => _supplierRepository = supplierRepository;

        public async Task<Guid> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplierEntity = SupplierMapper.Mapper.Map<Supplier>(request);
            if (supplierEntity == null)
            {
                throw new InvalidCastException(nameof(supplierEntity));
            }

            return (await _supplierRepository.AddAsync(supplierEntity)).Id;
        }
    }
}
