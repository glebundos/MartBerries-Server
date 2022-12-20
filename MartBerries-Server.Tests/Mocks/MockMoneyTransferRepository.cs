using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using Moq;

namespace MartBerries_Server.Tests.Mocks;

public class MockMoneyTransferRepository
{
    public static Mock<IMoneyTransferRepository> GetMoneyTransferRepos()
    {
        var moneyTransfers = new List<MoneyTransfer>
        {
            new MoneyTransfer
            {
                Id = Guid.Parse("3d85096a-1149-4729-90e7-c9238b858661"),
                TransferDateTime = DateTime.Now,
                TransactionTypeId = 1,
                TransactionType = MoneyTransfer.TransactionTypes.Expense,
                Amount = 3
            },
            new MoneyTransfer
            {
                Id = Guid.Parse("6359cece-903c-408c-9717-cef55f03eff4"),
                TransferDateTime = DateTime.Now,
                TransactionTypeId = 2,
                TransactionType = MoneyTransfer.TransactionTypes.Expense,
                Amount = 12
            },
            new MoneyTransfer
            {
                Id = Guid.Parse("d5f2502a-3ac2-42b0-900d-2a5bf65f0bf5"),
                TransferDateTime = DateTime.Now,
                TransactionTypeId = 3,
                TransactionType = MoneyTransfer.TransactionTypes.Expense,
                Amount = 10
            }
        };
        var mockRepo = new Mock<IMoneyTransferRepository>();

        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(moneyTransfers);

        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Guid id) => moneyTransfers.FirstOrDefault(x => x.Id == id));
        
        mockRepo.Setup(r => r.AddAsync(It.IsAny<MoneyTransfer>())).ReturnsAsync(
            (MoneyTransfer moneyTransfer) =>
            {
                moneyTransfer.Id = Guid.NewGuid();
                moneyTransfers.Add(moneyTransfer);
                return moneyTransfer;
            });

        mockRepo.Setup(r => r.UpdateAsync(It.IsAny<MoneyTransfer>())).ReturnsAsync(
            (MoneyTransfer moneyTransfer) =>
            {
                var index = moneyTransfers.FindIndex(f => f.Id == moneyTransfer.Id);

                if (index == -1)
                {
                    return null;
                }

                moneyTransfers[index] = moneyTransfer;
                return moneyTransfer;
            });

        mockRepo.Setup(r => r.DeleteAsync(It.IsAny<MoneyTransfer>())).Returns(
            (MoneyTransfer moneyTransfer) =>
            {
                moneyTransfers.Remove(moneyTransfer);
                return Task.FromResult(1);
            });

        return mockRepo;
    }
    }
