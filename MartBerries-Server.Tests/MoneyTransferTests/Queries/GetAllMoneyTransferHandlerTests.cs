using MartBerries_Server.Application.Handlers.QueryHandlers;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MartBerries_Server.Tests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MartBerries_Server.Tests.MoneyTransferTests.Queries
{
    public class GetAllMoneyTransferHandlerTests
    {
        private readonly Mock<IMoneyTransferRepository> _mockRepo;

        public GetAllMoneyTransferHandlerTests()
        {
            _mockRepo = MockMoneyTransferRepository.GetMoneyTransferRepository();
        }

        [Fact]
        public async Task GetAllMoneyTransferTest()
        {
            var handler = new GetAllMoneyTransferHandler(_mockRepo.Object);

            var response = await handler.Handle(new Application.Queries.GetAllMoneyTransferQuery(), CancellationToken.None);

            Assert.IsType<List<MoneyTransfer>>(response);

            Assert.Equal(3, response.Count);
        }
    }
}
