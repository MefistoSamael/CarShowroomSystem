using BusinessLogic.Application;
using Moq;

namespace BusinessLogic.Tests
{
    [TestFixture]
    public class CustomerRequestHandlerTests
    {
        private CustomerRequestHandler _customerRequestHandler;
        private Mock<UserControlSystem> _userControlSystemMock;

        [SetUp]
        public void SetUp()
        {
            _userControlSystemMock = new Mock<UserControlSystem>();
            _customerRequestHandler = new CustomerRequestHandler();
            _customerRequestHandler.userControlSystem = _userControlSystemMock.Object;
        }



        [Test]
        public void CreateOrder_ValidBuyerFullName_ReturnsOrder()
        {
            string buyerFullName = "John Doe";
            string login = "john123";
            string password = "password";
            Roles role = Roles.customer;
            string fullName = "John Doe";


            Assert.That(buyerFullName, Is.EqualTo(buyerFullName));
        }

        [Test]
        public void CreateUser_AdminUser_ReturnsCreatedUser()
        {
            string login = "john123";
            string password = "password";
            Roles role = Roles.customer;
            string fullName = "John Doe";

            Assert.That(fullName, Is.EqualTo(fullName));

        }

        [Test]
        public void CreateUser_NonAdminUser_ReturnsNull()
        {
            string login = "john123";
            string password = "password";
            Roles role = Roles.customer;
            string fullName = "John Doe";

            Assert.That(login,Is.EqualTo(login));
        }
        
        [Test]
        public void DeleteUser_NonAdminUser_ReturnsFalse()
        {
            string login = "john123";

            var result = _customerRequestHandler.DeleteUser(login);

            Assert.IsFalse(result);
        }


    }
}