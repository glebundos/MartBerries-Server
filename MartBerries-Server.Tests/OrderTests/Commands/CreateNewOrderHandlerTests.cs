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
        _mockOrderedProductRepo = MockOrderProductRepo.GetOrderProductRepository();
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
            OrderedProducts = null
        };
        var response = await handler.Handle(order, CancellationToken.None);
        
        Assert.Equal(order.CustomerName, response.CustomerName);
    }

}