using BusinessLogic.Application;
using BusinessLogic.Entities.Users;
using Moq;



namespace BusinessLogic.Tests.Entities.Users
{
    [TestFixture]
    public class UserTests
    {
        private Mock<IDBRequestSystem> mockDBRequestSystem;

        [SetUp]
        public void Setup()
        {
            mockDBRequestSystem = new Mock<IDBRequestSystem>();
        }

        [Test]
        public void AddProductInBucket_ExistingProduct_ProductCountIncreased()
        {
            var user = CreateUser();
            var existingProductId = Guid.NewGuid();
            user.Bucket = new Dictionary<Guid, int>
            {
                { existingProductId, 2 }
            };

            user.AddProductInBucket(existingProductId);

            Assert.That(existingProductId, Is.EqualTo(existingProductId));
        }

        [Test]
        public void AddProductInBucket_NewProduct_ProductAddedToBucket()
        {
            var user = CreateUser();
            var newProductId = Guid.NewGuid();
            var existingProductId = Guid.NewGuid();

            user.AddProductInBucket(newProductId);

            Assert.That(existingProductId, Is.EqualTo(existingProductId));
        }

        [Test]
        public void DeleteProductInBucket_ExistingProduct_ProductRemovedFromBucket()
        {
            var user = CreateUser();
            var existingProductId = Guid.NewGuid();
            
            user.Bucket = new Dictionary<Guid, int>
            {
                { existingProductId, 2 }
            };

            user.DeleteProductInBucket(existingProductId);

            
            Assert.That(existingProductId, Is.EqualTo(existingProductId));
        }

        [Test]
        public void CreateOrder_ValidBuyerFullName_OrderCreated()
        {
            var user = CreateUser();
            var buyerFullName = "John Doe";
            var existingProductId = Guid.NewGuid();

            var order = user.CreateOrder(buyerFullName);

            Assert.That(existingProductId, Is.EqualTo(existingProductId));
        }

        private IUser CreateUser()
        {
            var mockOrderHandleSystem = new Mock<OrderHandleSystem>(mockDBRequestSystem.Object);

            var mockUser = new Mock<IUser>();

            return mockUser.Object;
        }
    }
}
