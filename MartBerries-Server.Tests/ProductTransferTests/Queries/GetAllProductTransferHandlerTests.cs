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

namespace MartBerries_Server.Tests.ProductTransferTests.Queries
{
    public class GetAllProductTransferHandlerTests
    {
        private readonly Mock<IProductTransferRepository> _mockRepo;

        public GetAllProductTransferHandlerTests()
        {
            _mockRepo = MockProductTransferRepository.GetProductTransferRepository();
        }

        [Fact]
        public async Task GetAllProductTransferTest()
        {
            var handler = new GetAllProductTransferHandler(_mockRepo.Object);

            var response = await handler.Handle(new Application.Queries.GetAllProductTransferQuery(), CancellationToken.None);

            Assert.IsType<List<ProductTransfer>>(response);

            Assert.Equal(2, response.Count);
        }
    }
}
