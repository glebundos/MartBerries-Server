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
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepo;

        public CreateProductHandler(IProductRepository productRepo) => _productRepo = productRepo;

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = ProductMapper.Mapper.Map<Product>(request);

            if (productEntity == null)
            {
                return Guid.Empty;
            }

            return (await _productRepo.AddAsync(productEntity)).Id;
        }
    }
}
