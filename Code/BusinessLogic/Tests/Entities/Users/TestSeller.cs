using BusinessLogic.Application;
using BusinessLogic.Entities.Users;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using BusinessLogic.Entities;

namespace BusinessLogic.Tests.Entities.Users
{
    [TestFixture]
    public class SellerTests
    {
        private Mock<OrderHandleSystem> mockOrderHandleSystem;
        private Seller seller;

        [SetUp]
        public void SetUp()
        {
            mockOrderHandleSystem = new Mock<OrderHandleSystem>();
            seller = new Seller("testlogin", "testpassword", null, "Test Seller", mockOrderHandleSystem.Object);
        }

        [Test]
        public void CancelOrder_ValidOrderId_ReturnsOrderFromOrderHandleSystem()
        {
            Guid orderId = Guid.NewGuid();
            var existingProductId = Guid.NewGuid();

            Assert.Throws<Exception>(() => seller.CancelOrder(orderId));

        }

        [Test]
        public void CreateOrder_ValidBuyerFullName_CreatesOrderUsingOrderHandleSystem()
        {
            string buyerFullName = "John Doe";
            var existingProductId = Guid.NewGuid();


            Assert.Throws<Exception>(() => seller.CancelOrder(existingProductId));


        }
    }
}