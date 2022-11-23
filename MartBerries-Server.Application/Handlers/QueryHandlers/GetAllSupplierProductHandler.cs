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
    public class GetAllSupplierProductHandler : IRequestHandler<GetAllSupplierProductQuery, List<SupplierProduct>>
    {
        private readonly ISupplierProductRepository _supplierProductRepo;

        public GetAllSupplierProductHandler(ISupplierProductRepository supplierProductRepo) => _supplierProductRepo = supplierProductRepo;

        public async Task<List<SupplierProduct>> Handle(GetAllSupplierProductQuery request, CancellationToken cancellationToken)
        {
            var supplierProducts = (List<SupplierProduct>)await _supplierProductRepo.GetAllAsync();
            if (supplierProducts == null || supplierProducts.Count == 0)
            {
                return null!;
            }

            return supplierProducts;
        }
    }
}
