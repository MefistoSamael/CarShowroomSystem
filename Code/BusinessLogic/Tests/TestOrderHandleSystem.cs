using BusinessLogic.Entities.Products;

namespace BusinessLogic.Application.Tests;

using BusinessLogic.Entities;
using Moq;
using NUnit.Framework;


[TestFixture]
public class TestOrderHandleSystem  
{
    [Test]
    public void Constructor_WhenCalled_InitializesDB()
    {
        // Arrange
        var mockDB = new Mock<IDBRequestSystem>();

        // Act
        var orderHandleSystem = new OrderHandleSystem
        {
            DB = mockDB.Object
        };

        // Assert
        Assert.NotNull(orderHandleSystem.DB);
    }
    
        [Test]
        public void CreateOrder_WhenBucketIsNull_ThrowsException()
        {
            // Arrange
            var mockDB = new Mock<IDBRequestSystem>();
            var orderHandleSystem = new OrderHandleSystem
            {
                DB = mockDB.Object
            };
            var creatorLogin = "admin";
            string byerFullName = "John Doe";
            Dictionary<Guid, int> bucket = null;

            // Act + Assert
            Assert.Throws<Exception>(() => orderHandleSystem.CreateOrder(creatorLogin, byerFullName, bucket));
        }
    
        /// <summary>
        ///
        ///Вот этот тест не проходит
        /// 
        /// </summary>
        
        
        [TestFixture]
        public class OrderHandleSystemTests
        {
            [Test]
            public void CalculateBucketPrice_WhenCalled_ReturnsCorrectPrice()
            {
                // Arrange
                var mockDB = new Mock<IDBRequestSystem>();
                var orderHandleSystem = new OrderHandleSystem
                {
                    DB = mockDB.Object
                };
                var bucket = new Dictionary<Guid, int>
                {
                    { Guid.NewGuid(), 2 },
                    { Guid.NewGuid(), 3 },
                    { Guid.NewGuid(), 1 }
                };

                var product1 = new Product { Price = 10 };
                var product2 = new Product { Price = 20 };
                var product3 = new Product { Price = 30 };

                mockDB.Setup(m => m.GetProductByGuid(It.IsAny<Guid>())).Returns((Guid guid) =>
                {
                    if (guid == product1.Id) return product1;
                    if (guid == product2.Id) return product2;
                    if (guid == product3.Id) return product3;
                    return null;
                });

                // Act
                var price = orderHandleSystem.CalculateBucketPrice(bucket);

                // Assert
                var expectedPrice = 2 * product1.Price + 3 * product2.Price + 1 * product3.Price;
                Assert.AreEqual(expectedPrice, price);
            }
        }

    
}
