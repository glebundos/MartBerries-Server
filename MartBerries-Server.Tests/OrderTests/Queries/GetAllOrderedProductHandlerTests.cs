using MartBerries_Server.Application.Handlers.QueryHandlers;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MartBerries_Server.Tests.Mocks;
using Moq;
using Xunit;

namespace MartBerries_Server.Tests.OrderTests.Queries;

public class GetAllOrderedProductHandlerTests
{
    private readonly Mock<IOrderedProductRepository> _mockOrderedProductRepo;

    public GetAllOrderedProductHandlerTests()
    {
        _mockOrderedProductRepo = MockOrderProductRepository.GetOrderProductRepository();
    }

    [Fact]
    public async Task GetAllOrderedProductTest()
    {
        var handler = new GetAllOrderedProductHandler(_mockOrderedProductRepo.Object);

        var response = await handler.Handle(new GetAllOrderedProductQuery(), CancellationToken.None);

        Assert.IsType<List<OrderedProduct>>(response);
    }
}