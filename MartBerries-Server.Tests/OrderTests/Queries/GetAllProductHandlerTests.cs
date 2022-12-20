using MartBerries_Server.Application.Handlers.QueryHandlers;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MartBerries_Server.Tests.Mocks;
using Moq;
using Xunit;

namespace MartBerries_Server.Tests.OrderTests.Queries;

public class GetAllProductHandlerTests
{
    private readonly Mock<IProductRepository> _mockProductRepo;

    public GetAllProductHandlerTests()
    {
        _mockProductRepo = MockProductRepository.GetProductRepository();
    }
    [Fact]
    public async Task GetAllProductTest()
    {
        var handler = new GetAllProductHandler(_mockProductRepo.Object);

        var response = await handler.Handle(new GetAllProductQuery(), CancellationToken.None);

        Assert.IsType<List<Product>>(response);

        Assert.Equal(3, response.Count);
    }
   
}