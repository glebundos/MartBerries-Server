﻿using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Tests.Mocks
{
    public class MockOrderRepository
    {
        public static Mock<IOrderRepository> GetOrderRepository()
        {
            var _orders = new List<Order>
            {
                new Order
                {
                    Id = Guid.Parse("7559c608-107e-4b18-8d94-8d1fb164d0ad"),
                    SubmittedDateTime = DateTime.Now,
                    SubmittedMoney = 0,
                    RequestedMoney = 100,
                    CustomerName = "Ivan",
                    CustomerPhoneNumber = "88005553535",
                    CustomerAdditionalInfo = "Address: Lenina 8, I want contactless delivery.",
                    OrderStatusId = 0,
                    Products = new List<OrderedProduct>
                    {
                        new OrderedProduct
                        {
                            Product = new Product
                            {
                                Id = Guid.Parse("11111111-10c2-4274-b497-f7ab3635f5a5"),
                                Amount = 100,
                                Price = 10000,
                                Name = "Pomelo"
                            }
                        },

                        new OrderedProduct
                        {
                            Product = new Product
                            {
                                Id = Guid.Parse("11112222-10c2-4274-b497-f7ab3635f5a5"),
                                Amount = 200,
                                Price = 20000,
                                Name = "IPhone 10"
                            }
                        }
                    }
                },

                new Order
                {
                    Id = Guid.Parse("5517d1cb-2c41-4f0f-b6a2-b9f5fc50b7ee"),
                    SubmittedDateTime = DateTime.Now,
                    SubmittedMoney = 1000,
                    RequestedMoney = 1000,
                    CustomerName = "Boris",
                    CustomerPhoneNumber = "+375293752929",
                    CustomerAdditionalInfo = "Address: Lenina 9.",
                    OrderStatusId = 3,
                    Products = new List<OrderedProduct>
                    {
                        new OrderedProduct
                        {
                            Product = new Product
                            {
                                Id = Guid.Parse("22221111-10c2-4274-b497-f7ab3635f5a5"),
                                Amount = 300,
                                Price = 30000,
                                Name = "Apple"
                            }
                        },

                        new OrderedProduct
                        {
                            Product = new Product
                            {
                                Id = Guid.Parse("22222222-10c2-4274-b497-f7ab3635f5a5"),
                                Amount = 400,
                                Price = 40000,
                                Name = "Samsung"
                            }
                        }
                    }
                },

                new Order
                {
                    Id = Guid.Parse("ec9968e7-2de9-457d-9e70-2ee561dc89a6"),
                    SubmittedDateTime = DateTime.Now,
                    SubmittedMoney = 0,
                    RequestedMoney = 250,
                    CustomerName = "Maks",
                    CustomerPhoneNumber = "+375443334420",
                    CustomerAdditionalInfo = "Address: Kurchatova 8.",
                    OrderStatusId = 0,
                    Products = new List<OrderedProduct>
                    {
                        new OrderedProduct
                        {
                            Product = new Product
                            {
                                Id = Guid.Parse("33331111-10c2-4274-b497-f7ab3635f5a5"),
                                Amount = 500,
                                Price = 50000,
                                Name = "Banana"
                            }
                        },

                        new OrderedProduct
                        {
                            Product = new Product
                            {
                                Id = Guid.Parse("33332222-10c2-4274-b497-f7ab3635f5a5"),
                                Amount = 600,
                                Price = 60000,
                                Name = "Huawei"
                            }
                        }
                    }
                }
            };

            var mockRepo = new Mock<IOrderRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(_orders);

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Guid id) => _orders.FirstOrDefault(x => x.Id == id));

            mockRepo.Setup(r => r.GetByStatusIdAsync(It.IsAny<int>())).ReturnsAsync((int statusId) => _orders.Where(x => x.OrderStatusId == statusId).ToList());

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Order>())).ReturnsAsync(
                (Order order) =>
            {
                order.Id = Guid.NewGuid();
                _orders.Add(order);
                return order;
            });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Order>())).ReturnsAsync(
                (Order order) =>
            {
                var index = _orders.FindIndex(f => f.Id == order.Id);

                if (index == -1)
                {
                    return null;
                }

                _orders[index] = order;
                return order;
            });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Order>())).Returns(
                (Order order) =>
            {
                _orders.Remove(order);
                return Task.FromResult(1);
            });

            return mockRepo;
        }
    }
}
