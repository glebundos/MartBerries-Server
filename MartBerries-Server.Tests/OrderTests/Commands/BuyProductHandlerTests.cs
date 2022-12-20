﻿using MartBerries_Server.Application.Handlers.CommandHandlers;
using MartBerries_Server.Core.Repositories;
using MartBerries_Server.Tests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MartBerries_Server.Tests.OrderTests.Commands
{
    public class BuyProductHandlerTests
    {
        private readonly Mock<IProductRepository> _mockProductRepo;

        private readonly Mock<ISupplierProductRepository> _mockSupplierProductRepo;

        private readonly Mock<IProductTransferRepository> _mockProductTransferRepo;

        public BuyProductHandlerTests()
        {
            _mockProductRepo = MockProductRepository.GetProductRepository();
            _mockSupplierProductRepo = MockSupplierProductRepository.GetSupplierProductRepository();
            _mockProductTransferRepo = MockProductTransferRepository.GetProductTransferRepository();
        }

        [Theory]
        [InlineData("ab90b99d-9db3-4f18-a554-53a0e4803198", 1)]
        [InlineData("329ddc2b-c964-4e53-ab3a-7693879961f1", 100)]
        public async Task BuyDifferrentProductTest(Guid id, int amount)
        {
            var handler = new BuyProductHandler(_mockProductRepo.Object, _mockSupplierProductRepo.Object, _mockProductTransferRepo.Object);

            var moneyTransfersCountBeforeImport = (await _mockProductTransferRepo.Object.GetAllAsync()).Count();

            var response = await handler.Handle(new Application.Commands.BuyProductCommand { Id = id, Amount = amount}, CancellationToken.None);

            var moneyTransfersCountAfterImport = (await _mockProductTransferRepo.Object.GetAllAsync()).Count();

            Assert.True(response);

            Assert.Equal(moneyTransfersCountBeforeImport + 1, moneyTransfersCountAfterImport);
        }

        [Theory]
        [InlineData("853d1fb8-108f-4f6a-a1e8-80c0e9a9f7fb", 10000)]
        public async Task BuyExistingProductTest(Guid id, int amount)
        {
            var handler = new BuyProductHandler(_mockProductRepo.Object, _mockSupplierProductRepo.Object, _mockProductTransferRepo.Object);

            var moneyTransfersCountBeforeImport = (await _mockProductTransferRepo.Object.GetAllAsync()).Count();

            var productName = (await _mockSupplierProductRepo.Object.GetByIdAsync(id)).Name;

            var productAmountBeforeImport = (await _mockProductRepo.Object.GetByNameAsync(productName)).Amount;

            var response = await handler.Handle(new Application.Commands.BuyProductCommand { Id = id, Amount = amount }, CancellationToken.None);

            var moneyTransfersCountAfterImport = (await _mockProductTransferRepo.Object.GetAllAsync()).Count();

            var productAmountAfterImport = (await _mockProductRepo.Object.GetByNameAsync(productName)).Amount;

            Assert.True(response);

            Assert.Equal(moneyTransfersCountBeforeImport + 1, moneyTransfersCountAfterImport);

            Assert.Equal(productAmountBeforeImport + amount, productAmountAfterImport);
        }

        [Theory]
        [InlineData("00000000-9db3-4f18-a554-53a0e4803198", 1)]
        [InlineData("00000000-c964-4e53-ab3a-7693879961f1", 100)]
        [InlineData("00000000-108f-4f6a-a1e8-80c0e9a9f7fb", 10000)]
        public async Task BuyProductThrowsExceptionTest(Guid id, int amount)
        {
            var handler = new BuyProductHandler(_mockProductRepo.Object, _mockSupplierProductRepo.Object, _mockProductTransferRepo.Object);

            Assert.ThrowsAsync<System.Exception>(async () => await handler.Handle(new Application.Commands.BuyProductCommand { Id = id, Amount = amount }, CancellationToken.None));
        }
    }
}
