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
    public class CreateSupplierProductHandler : IRequestHandler<CreateSupplierProductCommand, Guid>
    {
        private readonly ISupplierProductRepository _supplierProductRepo;

        public CreateSupplierProductHandler(ISupplierProductRepository supplierProductRepo) => _supplierProductRepo = supplierProductRepo;

        public async Task<Guid> Handle(CreateSupplierProductCommand request, CancellationToken cancellationToken)
        {
            var supplierProductEntity = SupplierProductMapper.Mapper.Map<SupplierProduct>(request);
            if  (supplierProductEntity == null)
            {
                return Guid.Empty;
            }

            return (await _supplierProductRepo.AddAsync(supplierProductEntity)).Id;
        }
    }
}
