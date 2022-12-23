using MartBerries_Server.Application.Handlers.QueryHandlers;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Application.Responses;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MartBerries_Server.Core.Repositories;
using MartBerries_Server.Tests.Mocks;

namespace MartBerries_Server.Tests.OrderTests.Queries
{
    public class GetOrderListHandlerTests
    {
        private readonly Mock<IOrderRepository> _mockRepo;

        public GetOrderListHandlerTests()
        {
            _mockRepo = MockOrderRepository.GetOrderRepository();
        }

        [Fact]
        public async Task GetAllOrdersTest()
        {
            var handler = new GetOrderListHandler(_mockRepo.Object);

            var response = await handler.Handle(new GetOrderListQuery(-1), CancellationToken.None);

            Assert.IsType<List<OrderResponse>>(response);

            Assert.Equal(3, response.Count);
        }

        [Fact]
        public async Task GetOrdersByStatusIdTest()
        {
            var handler = new GetOrderListHandler(_mockRepo.Object);

            var response = await handler.Handle(new GetOrderListQuery(0), CancellationToken.None);

            Assert.IsType<List<OrderResponse>>(response);

            Assert.Equal(2, response.Count);
        }

        [Fact]
        public async Task GetOrdersByStatusIdThrowsExceptionTest()
        {
            var handler = new GetOrderListHandler(_mockRepo.Object);

            Assert.ThrowsAsync<Exception>(async () => await handler.Handle(new GetOrderListQuery(7), CancellationToken.None));
        }
    }
}
