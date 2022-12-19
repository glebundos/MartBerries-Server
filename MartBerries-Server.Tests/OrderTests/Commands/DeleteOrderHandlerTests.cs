using MartBerries_Server.Application.Commands;
using MartBerries_Server.Application.Handlers.CommandHandlers;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Repositories;
using MartBerries_Server.Tests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MartBerries_Server.Tests.OrderTests.Commands
{
    public class DeleteOrderHandlerTests
    {
        private readonly Mock<IOrderRepository> _mockRepo;

        public DeleteOrderHandlerTests()
        {
            _mockRepo = MockOrderRepository.GetOrderRepository();
        }

        [Theory]
        [InlineData("7559c608-107e-4b18-8d94-8d1fb164d0ad")]
        [InlineData("5517d1cb-2c41-4f0f-b6a2-b9f5fc50b7ee")]
        [InlineData("ec9968e7-2de9-457d-9e70-2ee561dc89a6")]
        public async Task DeleteOrderTest(Guid id)
        {
            var handler = new DeleteOrderHandler(_mockRepo.Object);

            var result = await handler.Handle(new DeleteOrderCommand { Id = id }, CancellationToken.None);

            Assert.Equal(id, result);

            Assert.Equal(2, (await _mockRepo.Object.GetAllAsync()).Count);
        }

        [Theory]
        [InlineData("1111c608-107e-4b18-8d94-8d1fb164d0ad")]
        [InlineData("1111d1cb-2c41-4f0f-b6a2-b9f5fc50b7ee")]
        [InlineData("111168e7-2de9-457d-9e70-2ee561dc89a6")]
        public async Task DeleteOrderThrowsExceptionTest(Guid id)
        {
            var handler = new DeleteOrderHandler(_mockRepo.Object);

            Assert.ThrowsAsync<System.Exception>(async () => await handler.Handle(new DeleteOrderCommand { Id = id }, CancellationToken.None));
        }
    }
}
