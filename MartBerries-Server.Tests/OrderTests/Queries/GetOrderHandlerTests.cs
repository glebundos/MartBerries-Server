using MartBerries_Server.Application.Handlers.QueryHandlers;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MartBerries_Server.Tests.Mocks;
using Moq;
using Xunit;

namespace MartBerries_Server.Tests.OrderTests.Queries;

public class GetOrderHandlerTests
{
    private readonly Mock<IOrderRepository> _mockRepo;

    public GetOrderHandlerTests()
    {
        _mockRepo = MockOrderRepository.GetOrderRepository();
    }

    [Theory]
    [InlineData("5517d1cb-2c41-4f0f-b6a2-b9f5fc50b7ee")]
    [InlineData("7559c608-107e-4b18-8d94-8d1fb164d0ad")]
    public async Task GetOrderTest(Guid guid)
    {
        var handler = new GetOrderHandler(_mockRepo.Object);

        var response = await handler.Handle(new GetOrderQuery(guid),CancellationToken.None);

        Assert.IsType<Order>(response);

        Assert.Equal(guid,response.Id);
    }

    [Theory]
    [InlineData("00000000-2c41-4f0f-b6a2-b9f5fc50b7ee")]
    [InlineData("11111111-107e-4b18-8d94-8d1fb164d0ad")]
    public async Task GetOrderThrowsExceptionTest(Guid guid)
    {
        var handler = new GetOrderHandler(_mockRepo.Object);

        Assert.ThrowsAsync<System.Exception>(async () => await handler.Handle(new GetOrderQuery(guid),CancellationToken.None));    
    }

}