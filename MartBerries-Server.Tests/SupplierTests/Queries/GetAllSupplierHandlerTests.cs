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

namespace MartBerries_Server.Tests.SupplierTests.Queries
{
    public class GetAllSupplierHandlerTests
    {
        private readonly Mock<ISupplierRepository> _mockRepo;

        public GetAllSupplierHandlerTests()
        {
            _mockRepo = MockSupplierRepository.GetSupplierRepository();
        }

        [Fact]
        public async Task GetAllSupplierTest()
        {
            var handler = new GetAllSupplierHandler(_mockRepo.Object);

            var response = await handler.Handle(new Application.Queries.GetAllSupplierQuery(), CancellationToken.None);

            Assert.IsType<List<Supplier>>(response);

            Assert.Equal(3, response.Count);
        }
    }
}
