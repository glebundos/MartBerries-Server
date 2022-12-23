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
    public class GetAllOrderedProductHandler : IRequestHandler<GetAllOrderedProductQuery, List<OrderedProduct>>
    {
        private readonly IOrderedProductRepository _orderedProductRepo;

        public GetAllOrderedProductHandler(IOrderedProductRepository orderedProductRepo) => _orderedProductRepo = orderedProductRepo;

        public async Task<List<OrderedProduct>> Handle(GetAllOrderedProductQuery request, CancellationToken cancellationToken)
        {
            var orderedProducts = (List<OrderedProduct>)await _orderedProductRepo.GetAllAsync();

            return orderedProducts;
        }
    }
}
