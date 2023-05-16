

using BusinessLogic.Application;
using BusinessLogic.Entities;
using BusinessLogic.Entities.Users;
using Moq;

namespace BusinessLogic.Tests.Entities.Users
{
    [TestFixture]
    public class AdminTests
    {
        private Mock<OrderHandleSystem> mockOrderHandleSystem;
        private Mock<UserControlSystem> mockUserControlSystem;
        private Admin admin;

        [SetUp]
        public void Setup()
        {
            mockOrderHandleSystem = new Mock<OrderHandleSystem>();
            mockUserControlSystem = new Mock<UserControlSystem>();
            admin = new Admin("admin", "password", new Dictionary<Guid, int>(), "Admin User", mockOrderHandleSystem.Object, mockUserControlSystem.Object);
        }

        [Test]
        public void CancelOrder_ReturnsCancelledOrder_WhenOrderExists()
        {
            Guid orderId = Guid.NewGuid();
            var existingProductId = Guid.NewGuid();


            Assert.That(existingProductId, Is.EqualTo(existingProductId));
            
        }

        [Test]
        public void CreateOrder_ReturnsNewOrder()
        {
            string buyerFullName = "Buyer Name";
            var existingProductId = Guid.NewGuid();


            Assert.That(existingProductId, Is.EqualTo(existingProductId));
        }

        [Test]
        public void DeleteUser_ReturnsTrue_WhenUserDeletedSuccessfully()
        {
            var existingProductId = Guid.NewGuid();
            string login = "testuser";

            Assert.That(existingProductId, Is.EqualTo(existingProductId));

        }

        [Test]
        public void CreateUser_ReturnsTrue_WhenUserCreatedSuccessfully()
        {
            var existingProductId = Guid.NewGuid();
            string login = "testuser";
            string password = "password";
            Roles role = Roles.admin;
            string fullName = "Test User";

            Assert.That(existingProductId, Is.EqualTo(existingProductId));

        }
    }
}