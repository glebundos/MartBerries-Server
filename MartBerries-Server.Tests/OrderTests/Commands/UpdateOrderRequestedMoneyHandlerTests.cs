using MartBerries_Server.Application.Handlers.CommandHandlers;
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
    public class UpdateOrderRequestedMoneyHandlerTests
    {
        private readonly Mock<IOrderRepository> _mockRepo;

        public UpdateOrderRequestedMoneyHandlerTests()
        {
            _mockRepo = MockOrderRepository.GetOrderRepository();
        }

        [Theory]
        [InlineData("7559c608-107e-4b18-8d94-8d1fb164d0ad", 100)]
        [InlineData("5517d1cb-2c41-4f0f-b6a2-b9f5fc50b7ee", 1000)]
        [InlineData("ec9968e7-2de9-457d-9e70-2ee561dc89a6", 9999)]
        public async Task UpdateOrderRequestedMoneyTest(Guid id, decimal requestedMoney)
        {
            var handler = new UpdateOrderRequestedMoneyHandler(_mockRepo.Object);

            var response = await handler.Handle(new Application.Commands.UpdateOrderRequestedMoneyCommand { Id = id, RequestedMoney = requestedMoney}, CancellationToken.None);

            Assert.Equal(requestedMoney, response.RequestedMoney);
        }

        [Theory]
        [InlineData("00000000-107e-4b18-8d94-8d1fb164d0ad", 100)]
        [InlineData("00000000-2c41-4f0f-b6a2-b9f5fc50b7ee", 1000)]
        [InlineData("00000000-2de9-457d-9e70-2ee561dc89a6", 9999)]
        public async Task UpdateOrderRequestedMoneyThrowsExceptionTest(Guid id, decimal requestedMoney)
        {
            var handler = new UpdateOrderRequestedMoneyHandler(_mockRepo.Object);

            Assert.ThrowsAsync<System.Exception>(async () => await handler.Handle(new Application.Commands.UpdateOrderRequestedMoneyCommand { Id = id, RequestedMoney = requestedMoney }, CancellationToken.None));
        }
    }
}
