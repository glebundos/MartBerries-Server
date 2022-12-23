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
    public class MockProductTransferRepository
    {
        public static Mock<IProductTransferRepository> GetProductTransferRepository()
        {
            var _productTransfers = new List<ProductTransfer>
            { 
                new ProductTransfer
                {
                    Id = Guid.Parse("2ceb832e8da14f07a504bf1c97d6651f"),
                    ProductId = Guid.Parse("fc7faef7-c763-46f3-ad13-d9012781e5ac"),
                    TransferDateTime = DateTime.Now,
                    Amount = 200,
                    TransferTypeId = 0
                },

                new ProductTransfer
                {
                    Id = Guid.Parse("e03e54ba-c67f-40fb-aec9-6eb4df34ca4d"),
                    ProductId = Guid.Parse("a680c3a8-f01e-422a-a5cf-e1b2829dc118"),
                    TransferDateTime = DateTime.Now,
                    Amount = 100,
                    TransferTypeId = 1
                }
            };

            var mockRepo = new Mock<IProductTransferRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(_productTransfers);

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Guid id) => _productTransfers.FirstOrDefault(x => x.Id == id));

            mockRepo.Setup(r => r.AddAsync(It.IsAny<ProductTransfer>())).ReturnsAsync(
                (ProductTransfer productTransfer) =>
                {
                    productTransfer.Id = Guid.NewGuid();
                    _productTransfers.Add(productTransfer);
                    return productTransfer;
                });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<ProductTransfer>())).ReturnsAsync(
                (ProductTransfer productTransfer) =>
                {
                    var index = _productTransfers.FindIndex(f => f.Id == productTransfer.Id);

                    if (index == -1)
                    {
                        return null;
                    }

                    _productTransfers[index] = productTransfer;
                    return productTransfer;
                });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<ProductTransfer>())).Returns(
                (ProductTransfer productTransfer) =>
                {
                    _productTransfers.Remove(productTransfer);
                    return Task.FromResult(1);
                });

            mockRepo.Setup(r => r.AddRangeAsync(It.IsAny<List<ProductTransfer>>())).ReturnsAsync(
            (List<ProductTransfer> productTransfers) =>
            {
                _productTransfers.AddRange(productTransfers);
                return productTransfers;
            });

            return mockRepo;
        }
    }
}
