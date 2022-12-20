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
    public class MockSupplierProductRepository
    {
        public static Mock<ISupplierProductRepository> GetSupplierProductRepository()
        {
            var _supplierProducts = new List<SupplierProduct>
            {
                new SupplierProduct
                {
                    Id = Guid.Parse("ab90b99d-9db3-4f18-a554-53a0e4803198"),
                    SupplierId = Guid.Parse("0b8d2bd6-2556-4c24-8150-25125f1c88e8"),
                    Name = "Test1",
                    Price = 1000
                },

                new SupplierProduct
                {
                    Id = Guid.Parse("329ddc2b-c964-4e53-ab3a-7693879961f1"),
                    SupplierId = Guid.Parse("bc927f57-97e2-4903-936c-cab7163045ea"),
                    Name = "Test2",
                    Price = 2000
                },

                new SupplierProduct
                {
                    Id = Guid.Parse("853d1fb8-108f-4f6a-a1e8-80c0e9a9f7fb"),
                    SupplierId = Guid.Parse("2c697c2e-a7f7-409f-a46b-a708503ae7e0"),
                    Name = "TV",
                    Price = 3000
                }
            };

            var mockRepo = new Mock<ISupplierProductRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(_supplierProducts);

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Guid id) => _supplierProducts.FirstOrDefault(x => x.Id == id));

            mockRepo.Setup(r => r.AddAsync(It.IsAny<SupplierProduct>())).ReturnsAsync(
                (SupplierProduct supplierProduct) =>
                {
                    supplierProduct.Id = Guid.NewGuid();
                    _supplierProducts.Add(supplierProduct);
                    return supplierProduct;
                });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<SupplierProduct>())).ReturnsAsync(
                (SupplierProduct supplierProduct) =>
                {
                    var index = _supplierProducts.FindIndex(f => f.Id == supplierProduct.Id);

                    if (index == -1)
                    {
                        return null;
                    }

                    _supplierProducts[index] = supplierProduct;
                    return supplierProduct;
                });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<SupplierProduct>())).Returns(
                (SupplierProduct supplierProduct) =>
                {
                    _supplierProducts.Remove(supplierProduct);
                    return Task.FromResult(1);
                });

            return mockRepo;
        }
    }
}
