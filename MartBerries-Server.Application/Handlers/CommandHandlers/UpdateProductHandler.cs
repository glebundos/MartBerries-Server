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
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _productRepo;

        public UpdateProductHandler(IProductRepository productRepo) => _productRepo = productRepo;

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var oldProduct = await _productRepo.GetByIdAsync(request.Id);

            if (oldProduct == null)
            {
                throw new InvalidCastException(nameof(request));
            }

            oldProduct.Name = request.Name;
            oldProduct.Price = request.Price;
            oldProduct.Amount = request.Amount;

            var newProduct = await _productRepo.UpdateAsync(oldProduct);
            return newProduct;
        }
    }
}
