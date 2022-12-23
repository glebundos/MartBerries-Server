using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using Moq;

namespace MartBerries_Server.Tests.Mocks;

public class MockOrderProductRepository
{
    public static Mock<IOrderedProductRepository> GetOrderProductRepository()
    {
        var orderedProducts = new List<OrderedProduct>
        {
            new OrderedProduct
            {
                Amount = 3,
                Id = Guid.Parse("7559c608-107e-4b18-8d94-8d1fb164d0ad"),
                Order = new Order(),
                OrderId = Guid.Parse("7559c608-107e-4b18-8d94-9d2b164d0ad0"),
                Product = new Product(),
                ProductId = Guid.Parse("7559c608-107e-4b18-8d94-8d1fb164d1ef")
            },

            new OrderedProduct
            {
                Amount = 5,
                Id = Guid.Parse("def8ff40-22bb-4aea-a457-609ecbaef8b2"),
                Order = new Order(),
                OrderId = Guid.Parse("124dabfd-dd2b-4c9e-8902-ee57f5e7fdd0"),
                Product = new Product(),
                ProductId = Guid.Parse("d0127739-d04e-4e04-86e4-1325ba38e850")
            }
        };

        var mockRepo = new Mock<IOrderedProductRepository>();

        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(orderedProducts);

        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Guid id) => orderedProducts.FirstOrDefault(x => x.Id == id));
        
        mockRepo.Setup(r => r.AddAsync(It.IsAny<OrderedProduct>())).ReturnsAsync(
            (OrderedProduct orderedProduct) =>
        {
            orderedProduct.Id = Guid.NewGuid();
            orderedProducts.Add(orderedProduct);
            return orderedProduct;
        });

        mockRepo.Setup(r => r.UpdateAsync(It.IsAny<OrderedProduct>())).ReturnsAsync(
            (OrderedProduct orderedProduct) =>
        {
            var index = orderedProducts.FindIndex(f => f.Id == orderedProduct.Id);

            if (index == -1)
            {
                return null;
            }

            orderedProducts[index] = orderedProduct;
            return orderedProduct;
        });

        mockRepo.Setup(r => r.DeleteAsync(It.IsAny<OrderedProduct>())).Returns(
            (OrderedProduct orderedProduct) =>
        {
            orderedProducts.Remove(orderedProduct);
            return Task.FromResult(1);
        });

        mockRepo.Setup(r => r.AddRangeAsync(It.IsAny<List<OrderedProduct>>())).ReturnsAsync(
            (List<OrderedProduct> _OrderedProducts) =>
            {
                orderedProducts.AddRange(_OrderedProducts);
                return _OrderedProducts;
            });

        return mockRepo;
    }
}