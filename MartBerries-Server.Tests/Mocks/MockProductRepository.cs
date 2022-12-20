using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Tests.Mocks
{
    public class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var _products = new List<Product>
            {
                new Product
                {
                    Id = Guid.Parse("d1678194-74a6-4cae-85f2-0cc6769da83e"),
                    Name = "TV",
                    Price = 10000,
                    Amount = 50
                },

                new Product
                {
                    Id = Guid.Parse("ac5b0a07-b13c-414d-b696-95ed17dfce73"),
                    Name = "Microwave",
                    Price = 10000,
                    Amount = 50
                }
            };

            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(_products);

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Guid id) => _products.FirstOrDefault(x => x.Id == id));

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Product>())).ReturnsAsync(
                (Product product) =>
                {
                    product.Id = Guid.NewGuid();
                    _products.Add(product);
                    return product;
                });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Product>())).ReturnsAsync(
                (Product product) =>
                {
                    var index = _products.FindIndex(f => f.Id == product.Id);

                    if (index == -1)
                    {
                        return null;
                    }

                    _products[index] = product;
                    return product;
                });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Product>())).Returns(
                (Product product) =>
                {
                    _products.Remove(product);
                    return Task.FromResult(1);
                });

            mockRepo.Setup(r => r.GetByNameAsync(It.IsAny<string>())).ReturnsAsync((string name) => _products.FirstOrDefault(x => x.Name == name));

            return mockRepo;
        }
    }
}
