using MartBerries_Server.Application.Commands;
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
    public class UpdateOrderStatusHandlerTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepo;

        private readonly Mock<IProductTransferRepository> _mockProductTransferRepo;

        private readonly Mock<IProductRepository> _mockProductRepo;

        public UpdateOrderStatusHandlerTests()
        {
            _mockOrderRepo = MockOrderRepository.GetOrderRepository();
            _mockProductTransferRepo = MockProductTransferRepository.GetProductTransferRepository();
            _mockProductRepo = MockProductRepository.GetProductRepository();
        }

        [Theory]
        [InlineData("7559c608-107e-4b18-8d94-8d1fb164d0ad", 1)]
        [InlineData("5517d1cb-2c41-4f0f-b6a2-b9f5fc50b7ee", 2)]
        [InlineData("ec9968e7-2de9-457d-9e70-2ee561dc89a6", 1)]
        public async Task UpdateOrderStatusTest(Guid id, int statusId)
        {
            var handler = new UpdateOrderStatusHandler(_mockOrderRepo.Object, _mockProductRepo.Object, _mockProductTransferRepo.Object);

            var response = await handler.Handle(new UpdateOrderStatusCommand { Id = id, StatusId = statusId }, CancellationToken.None);

            Assert.Equal(statusId, response.OrderStatusId);
        }

        [Theory]
        [InlineData("7559c608-107e-4b18-8d94-8d1fb164d0ad", 4)]
        [InlineData("5517d1cb-2c41-4f0f-b6a2-b9f5fc50b7ee", 4)]
        [InlineData("ec9968e7-2de9-457d-9e70-2ee561dc89a6", 4)]
        public async Task UpdateOrderStatusInDeliveryTest(Guid id, int statusId)
        {
            var handler = new UpdateOrderStatusHandler(_mockOrderRepo.Object, _mockProductRepo.Object, _mockProductTransferRepo.Object);

            await handler.Handle(new UpdateOrderStatusCommand { Id = id, StatusId = statusId }, CancellationToken.None);

            Assert.Equal(4, (await _mockProductTransferRepo.Object.GetAllAsync()).Count);
        }

        [Theory]
        [InlineData("00000000-107e-4b18-8d94-8d1fb164d0ad", 1)]
        [InlineData("00000000-2c41-4f0f-b6a2-b9f5fc50b7ee", 2)]
        [InlineData("00000000-2de9-457d-9e70-2ee561dc89a6", 1)]
        public async Task UpdateOrderStatusThrowsExceptionTest(Guid id, int statusId)
        {
            var handler = new UpdateOrderStatusHandler(_mockOrderRepo.Object, _mockProductRepo.Object, _mockProductTransferRepo.Object);

            Assert.ThrowsAsync<System.Exception>(async () => await handler.Handle(new UpdateOrderStatusCommand { Id = id, StatusId = statusId }, CancellationToken.None));
        }
    }
}
