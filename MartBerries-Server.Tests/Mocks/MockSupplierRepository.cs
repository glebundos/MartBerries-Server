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
    public class MockSupplierRepository
    {
        public static Mock<ISupplierRepository> GetSupplierRepository()
        {
            var _suppliers = new List<Supplier>
            {
                new Supplier
                {
                    Id = Guid.Parse("813a8b77-f026-4e76-bbcb-9a17d7cf1f09"),
                    Name = "Test1",
                },

                new Supplier
                {
                    Id = Guid.Parse("7fbe6d22-7e0d-407f-8bbb-f8c6b5c24454"),
                    Name = "Test2",
                },

                new Supplier
                {
                    Id = Guid.Parse("f1d08c7e-e503-4845-9384-ad4911e8ed7a"),
                    Name = "Test3",
                }
            };

            var mockRepo = new Mock<ISupplierRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(_suppliers);

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Guid id) => _suppliers.FirstOrDefault(x => x.Id == id));

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Supplier>())).ReturnsAsync(
                (Supplier supplier) =>
                {
                    supplier.Id = Guid.NewGuid();
                    _suppliers.Add(supplier);
                    return supplier;
                });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Supplier>())).ReturnsAsync(
                (Supplier supplier) =>
                {
                    var index = _suppliers.FindIndex(f => f.Id == supplier.Id);

                    if (index == -1)
                    {
                        return null;
                    }

                    _suppliers[index] = supplier;
                    return supplier;
                });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Supplier>())).Returns(
                (Supplier supplier) =>
                {
                    _suppliers.Remove(supplier);
                    return Task.FromResult(1);
                });

            return mockRepo;
        }
    }
}
