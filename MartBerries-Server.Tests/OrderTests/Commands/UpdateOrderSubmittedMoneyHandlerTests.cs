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
    public class UpdateOrderSubmittedMoneyHandlerTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepo;

        private readonly Mock<IMoneyTransferRepository> _mockMoneyTransferRepo;

        public UpdateOrderSubmittedMoneyHandlerTests()
        {
            _mockOrderRepo = MockOrderRepository.GetOrderRepository();
            _mockMoneyTransferRepo = MockMoneyTransferRepository.GetMoneyTransferRepository();
        }

        [Theory]
        [InlineData("7559c608-107e-4b18-8d94-8d1fb164d0ad", 100)]
        [InlineData("ec9968e7-2de9-457d-9e70-2ee561dc89a6", 100)]
        [InlineData("ec9968e7-2de9-457d-9e70-2ee561dc89a6", 150)]
        public async Task UpdateOrderSubmittedMoneyTest(Guid id, decimal submittedMoney)
        {
            var handler = new UpdateOrderSubmittedMoneyHandler(_mockOrderRepo.Object, _mockMoneyTransferRepo.Object);

            var alreadySubmittedMoney = (await _mockOrderRepo.Object.GetByIdAsync(id)).SubmittedMoney;

            var moneyTransfersCountBeforeUpdate = (await _mockMoneyTransferRepo.Object.GetAllAsync()).Count;

            var response = await handler.Handle(new Application.Commands.UpdateOrderSubmittedMoneyCommand { Id = id, SubmittedMoney = submittedMoney}, CancellationToken.None);

            var moneyTransfersCountAfterUpdate = (await _mockMoneyTransferRepo.Object.GetAllAsync()).Count;

            Assert.Equal(submittedMoney, response.SubmittedMoney - alreadySubmittedMoney);

            Assert.Equal(moneyTransfersCountBeforeUpdate + 1, moneyTransfersCountAfterUpdate);
        }

        [Theory]
        [InlineData("00000000-107e-4b18-8d94-8d1fb164d0ad", 100)]
        [InlineData("00000000-2de9-457d-9e70-2ee561dc89a6", 100)]
        [InlineData("00000000-2de9-457d-9e70-2ee561dc89a6", 150)]
        public async Task UpdateOrderSubmittedMoneyThrowsExceptionTest(Guid id, decimal submittedMoney)
        {
            var handler = new UpdateOrderSubmittedMoneyHandler(_mockOrderRepo.Object, _mockMoneyTransferRepo.Object);

            Assert.ThrowsAsync<System.Exception>(async () => await handler.Handle(new Application.Commands.UpdateOrderSubmittedMoneyCommand { Id = id, SubmittedMoney = submittedMoney }, CancellationToken.None));
        }
    }
}
