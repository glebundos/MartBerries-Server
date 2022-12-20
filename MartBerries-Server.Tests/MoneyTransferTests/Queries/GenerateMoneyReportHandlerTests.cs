using System.Text;
using MartBerries_Server.Application.Handlers.QueryHandlers;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MartBerries_Server.Infrastructure;
using MartBerries_Server.Tests.Mocks;
using Moq;
using Xunit;

namespace MartBerries_Server.Tests.MoneyTransferTests.Queries;

public class GenerateMoneyReportHandlerTests
{
    private readonly Mock<IMoneyTransferRepository> _mockMoneyTransferRepo;

    public GenerateMoneyReportHandlerTests()
    {
        _mockMoneyTransferRepo = MockMoneyTransferRepository.GetMoneyTransferRepository();
    }

    [Fact]
    public async Task GenerateMoneyReportTest()
    {
        var handler = new GenerateMoneyReportHandler(_mockMoneyTransferRepo.Object);

        var moneyTransfers = (List<MoneyTransfer>)await _mockMoneyTransferRepo.Object.GetAllAsync();

        var response = await handler.Handle(new GenerateMoneyReportQuery(), CancellationToken.None);

        string reportString = MoneyTransferReportGenerator.Generate(moneyTransfers);

        Assert.IsType<List<MoneyTransfer>>(moneyTransfers);

        Assert.Equal(Encoding.UTF8.GetBytes(reportString), response);
    }

    [Fact]
    public async Task GetGenerateMoneyReportThrowsExceptionTest()
    {
        var handler = new GenerateMoneyReportHandler(_mockMoneyTransferRepo.Object);

        var moneyTransfers = (List<MoneyTransfer>)await _mockMoneyTransferRepo.Object.GetAllAsync();

        Assert.ThrowsAsync<Exception>(async () => await handler.Handle(new GenerateMoneyReportQuery(), CancellationToken.None));
    }

}