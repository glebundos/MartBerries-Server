using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Handlers.QueryHandlers
{
    public class GetAllSupplierHandler : IRequestHandler<GetAllSupplierQuery, List<Supplier>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetAllSupplierHandler(ISupplierRepository supplierRepository) => _supplierRepository = supplierRepository;

        public async Task<List<Supplier>> Handle(GetAllSupplierQuery request, CancellationToken cancellationToken)
        {
            var suppliers = (List<Supplier>)await _supplierRepository.GetAllAsync();

            return suppliers;
        }
    }
}
