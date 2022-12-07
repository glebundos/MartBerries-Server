using MartBerries_Server.Core.Repositories;
using MartBerries_Server.Tests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Tests.OrderTests.Queries.Base
{
    public class OrderQueryHandlerBase
    {
        protected readonly Mock<IOrderRepository> _mockRepo;

        public OrderQueryHandlerBase()
        {
            _mockRepo = MockOrderRepository.GetOrderRepository();
        }

    }
}
