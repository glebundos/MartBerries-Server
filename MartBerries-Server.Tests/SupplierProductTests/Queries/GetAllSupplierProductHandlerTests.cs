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

namespace MartBerries_Server.Tests.SupplierProductTests.Queries
{
    public class GetAllSupplierProductHandlerTests
    {
        private readonly Mock<ISupplierProductRepository> _mockRepo;

        public GetAllSupplierProductHandlerTests()
        {
            _mockRepo = MockSupplierProductRepository.GetSupplierProductRepository();
        }

        [Fact]
        public async Task GetAllSupplierProductTest()
        {
            var handler = new GetAllSupplierProductHandler(_mockRepo.Object);

            var response = await handler.Handle(new Application.Queries.GetAllSupplierProductQuery(), CancellationToken.None);

            Assert.IsType<List<SupplierProduct>>(response);

            Assert.Equal(3, response.Count);
        }
    }
}
