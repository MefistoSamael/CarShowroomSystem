using System;
using BusinessLogic.Application;
using BusinessLogic.Entities.Products;
using Moq;
using NUnit.Framework;

namespace BusinessLogic.Tests
{
    [TestFixture]
    public class ProductCreatorTests
    {
        private Mock<IDBRequestSystem>? _mockDb;

        [SetUp]
        public void Setup()
        {
            _mockDb = new Mock<IDBRequestSystem>();
        }

        [Test]
        public void CreateProduct_ShouldReturnProductWithCorrectProperties()
        {
            // Arrange
            if (_mockDb == null) return;
            var productCreator = new ProductCreator { db = _mockDb.Object };
            var id = Guid.NewGuid();
            var name = "AhuitelnayaTachka";
            var manufacturer = "BMW";
            var inStock = true;
            var price = 1m;

            // Act
            var result = productCreator.CreateProduct(id, name, manufacturer, inStock, price);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(name, result.Name);
            Assert.AreEqual(manufacturer, result.Manufacturer);
            Assert.AreEqual(inStock, result.InStock);
            Assert.AreEqual(price, result.Price);

            _mockDb.Verify(x => x.AddProduct(result), Times.Once);
        }
    }
}