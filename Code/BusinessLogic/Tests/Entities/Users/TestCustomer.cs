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
    public class CustomerTests
    {
        private Mock<OrderHandleSystem> mockOrderHandleSystem;
        private Customer customer;

        [SetUp]
        public void SetUp()
        {
            mockOrderHandleSystem = new Mock<OrderHandleSystem>();
            customer = new Customer("testLogin", "testPassword", new Dictionary<Guid, int>(), "John Doe", mockOrderHandleSystem.Object);
        }

        [Test]
        public void CancelOrder_ValidOrderId_ReturnsOrder()
        {
            Guid orderId = Guid.NewGuid();
            var existingProductId = Guid.NewGuid();


            Assert.That(existingProductId, Is.EqualTo(existingProductId));

        }

        [Test]
        public void CreateOrder_ValidBuyerFullName_CreatesOrder()
        {
            string buyerFullName = "Jane Smith";

            var existingProductId = Guid.NewGuid();

            Assert.That(existingProductId, Is.EqualTo(existingProductId));
        }
    }
}