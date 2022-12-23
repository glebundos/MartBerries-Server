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
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<Product>>
    {
        private readonly IProductRepository _productRepo;

        public GetAllProductHandler(IProductRepository productRepo) => _productRepo = productRepo;

        public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = (List<Product>)await _productRepo.GetAllAsync();

            return products;
        }
    }
}
