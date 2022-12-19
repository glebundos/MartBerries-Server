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
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Guid>
    {
        private readonly IProductRepository _productRepo;

        public DeleteProductHandler(IProductRepository productRepo) => _productRepo = productRepo;

        public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetByIdAsync(request.Id);

            if (product == null) 
            {
                throw new Exception(message: "Product not found");
            }

            await _productRepo.DeleteAsync(product);
            return product.Id;
        }
    }
}
