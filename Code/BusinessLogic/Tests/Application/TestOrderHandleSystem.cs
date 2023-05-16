using BusinessLogic.Application;
using BusinessLogic.Entities;
using BusinessLogic.Entities.Products;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BusinessLogic.Tests
{
    [TestFixture]
    public class OrderHandleSystemTests
    {
        private OrderHandleSystem orderHandleSystem;
        private Mock<IDBRequestSystem> dbMock;

        [SetUp]
        public void SetUp()
        {
            dbMock = new Mock<IDBRequestSystem>();

            orderHandleSystem = new OrderHandleSystem();
            orderHandleSystem.DB = dbMock.Object;
        }
        
        
        
    [TestFixture]
    public class OrderHandleSystemTests2
    {
        private OrderHandleSystem orderHandleSystem;
        private Mock<IDBRequestSystem> dbMock;

        [SetUp]
        public void SetUp()
        {
            dbMock = new Mock<IDBRequestSystem>();
            orderHandleSystem = new OrderHandleSystem();
            orderHandleSystem.DB = dbMock.Object;
        }


        [Test]
        public void CreateOrder_ValidInput_CreatesAndReturnsOrder()
        {
            string creatorLogin = "john123";
            string buyerFullName = "John Doe";
            Dictionary<Guid, int> bucket = new Dictionary<Guid, int>
            {
                { Guid.NewGuid(), 2 },
                { Guid.NewGuid(), 3 },
            };
        }

        [Test]
        public void CreateOrder_NullBucket_ThrowsException()
        {
            string creatorLogin = "john123";
            string buyerFullName = "John Doe";

            Assert.Throws<Exception>(() => orderHandleSystem.CreateOrder(creatorLogin, buyerFullName, null));
        }

        [Test]
        public void ReturnOrder_ExistingOrderId_CancelsAndReturnsOrder()
        {
            Guid orderId = Guid.NewGuid();

            Order result = orderHandleSystem.ReturnOrder(orderId);

        }

        [Test]
        public void ReturnOrder_NonExistingOrderId_ReturnsNull()
        {
            Guid orderId = Guid.NewGuid();
            dbMock.Setup(db => db.GetOrder(orderId)).Returns((Order)null);

            Order? result = orderHandleSystem.ReturnOrder(orderId);

            Assert.IsNull(result);
            dbMock.Verify(db => db.ChangeOrder(orderId, It.IsAny<Order>()), Times.Never);
        }
    }
        
         [TestFixture]
    public class OrderHandleSystemTests3
    {
        private OrderHandleSystem orderHandleSystem;
        private Mock<IDBRequestSystem> dbMock;

        [SetUp]
        public void SetUp()
        {
            dbMock = new Mock<IDBRequestSystem>();
            orderHandleSystem = new OrderHandleSystem();
            orderHandleSystem.DB = dbMock.Object;
        }


        [Test]
        public void CalculateBucketPrice_ValidBucket_ReturnsTotalPrice()
        {
            Guid productId1 = Guid.NewGuid();
            Guid productId2 = Guid.NewGuid();
            decimal price1 = 10.0m;
            decimal price2 = 20.0m;
            int quantity1 = 2;
            int quantity2 = 3;
            Dictionary<Guid, int> bucket = new Dictionary<Guid, int>
            {
                { productId1, quantity1 },
                { productId2, quantity2 },
            };
            Product product1 = new Product { Id = productId1, Price = price1 };
            Product product2 = new Product { Id = productId2, Price = price2 };
            dbMock.Setup(db => db.GetProductByGuid(productId1)).Returns(product1);
            dbMock.Setup(db => db.GetProductByGuid(productId2)).Returns(product2);

            decimal expectedPrice = price1 * quantity1 + price2 * quantity2;

            decimal result = orderHandleSystem.CalculateBucketPrice(bucket);

            Assert.AreEqual(expectedPrice, result);
        }

        [Test]
        public void CalculateBucketPrice_EmptyBucket_ReturnsZeroPrice()
        {
            Dictionary<Guid, int> bucket = new Dictionary<Guid, int>();

            decimal result = orderHandleSystem.CalculateBucketPrice(bucket);

            Assert.AreEqual(0, result);
        }

        
    }
        
    }
}