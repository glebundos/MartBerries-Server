using MartBerries_Server.Application.Commands;
using MartBerries_Server.Application.Handlers.CommandHandlers;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MartBerries_Server.Tests.Mocks;
using Moq;
using Xunit;

namespace MartBerries_Server.Tests.OrderTests.Commands;

public class CreateNewOrderHandlerTests
{
    private readonly Mock<IOrderedProductRepository> _mockOrderedProductRepo;

    private readonly Mock<IOrderRepository> _mockOrderRepo;

    public CreateNewOrderHandlerTests()
    {
        _mockOrderedProductRepo = MockOrderProductRepository.GetOrderProductRepository();
        _mockOrderRepo = MockOrderRepository.GetOrderRepository();
    }

    [Fact]
    public async Task CreatNewOrderTests()
    {
        var handler = new CreateNewOrderHandler(_mockOrderRepo.Object, _mockOrderedProductRepo.Object);

        var order = new CreateNewOrderCommand
        {
            CustomerName = "Vanya",
            CustomerPhoneNumber = "+375336675325",
            CustomerAdditionalInfo = "aboba",
            OrderedProducts = new List<CreateNewOrderCommand.OrderedProductModel>
            {
                new CreateNewOrderCommand.OrderedProductModel
                {
                    ProductId = Guid.NewGuid(),
                    Amount = 1,
                },

                new CreateNewOrderCommand.OrderedProductModel
                {
                    ProductId = Guid.NewGuid(),
                    Amount = 2,
                }
            }
        };

        var response = await handler.Handle(order, CancellationToken.None);
        
        var orders = await _mockOrderRepo.Object.GetAllAsync();

        var orderedProducts = await _mockOrderedProductRepo.Object.GetAllAsync();

        Assert.Equal(order.CustomerName, response.CustomerName);

        Assert.Equal(4, orders.Count);

        Assert.Equal(4, orderedProducts.Count);

        Assert.Equal(response.Id, orderedProducts[2].OrderId);

        Assert.Equal(response.Id, orderedProducts[3].OrderId);
    }

}