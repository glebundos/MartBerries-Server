using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Tests.Mocks
{
    public class MockMoneyTransferRepository
    {
        public static Mock<IMoneyTransferRepository> GetMoneyTransferRepository()
        {
            var _moneyTransfers = new List<MoneyTransfer>
            {
                new MoneyTransfer
                {
                    Id = Guid.Parse("4dfdf3bb-9bbe-46a9-bca6-9ec93af07565"),
                    TransferDateTime = DateTime.Now,
                    Amount = 10,
                    TransactionTypeId = 0
                },

                new MoneyTransfer
                {
                    Id = Guid.Parse("fe0dc5fb-1cef-495a-b1d7-eaa6ef73f57e"),
                    TransferDateTime = DateTime.Now,
                    Amount = 20,
                    TransactionTypeId = 1
                },

                new MoneyTransfer
                {
                    Id = Guid.Parse("9a8da71b-6c0c-4a49-b9e9-d9252c1f8c28"),
                    TransferDateTime = DateTime.Now,
                    Amount = 30,
                    TransactionTypeId = 0
                }
            };

            var mockRepo = new Mock<IMoneyTransferRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(_moneyTransfers);

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Guid id) => _moneyTransfers.FirstOrDefault(x => x.Id == id));

            mockRepo.Setup(r => r.AddAsync(It.IsAny<MoneyTransfer>())).ReturnsAsync(
                (MoneyTransfer moneyTransfer) =>
                {
                    moneyTransfer.Id = Guid.NewGuid();
                    _moneyTransfers.Add(moneyTransfer);
                    return moneyTransfer;
                });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<MoneyTransfer>())).ReturnsAsync(
                (MoneyTransfer moneyTransfer) =>
                {
                    var index = _moneyTransfers.FindIndex(f => f.Id == moneyTransfer.Id);

                    if (index == -1)
                    {
                        return null;
                    }

                    _moneyTransfers[index] = moneyTransfer;
                    return moneyTransfer;
                });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<MoneyTransfer>())).Returns(
                (MoneyTransfer moneyTransfer) =>
                {
                    _moneyTransfers.Remove(moneyTransfer);
                    return Task.FromResult(1);
                });

            return mockRepo;
        }
    }
}
