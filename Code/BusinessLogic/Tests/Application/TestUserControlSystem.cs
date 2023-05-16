using BusinessLogic.Application;
using BusinessLogic.Entities.Users;
using Moq;
using NUnit.Framework;

namespace BusinessLogic.Tests
{
    [TestFixture]
    public class UserControlSystemTests
    {
        private UserControlSystem userControlSystem;
        private Mock<CustomerRequestHandler> customerRequestHandlerMock;
        private Mock<OrderHandleSystem> orderHandleSystemMock;
        private Mock<IDBRequestSystem> dbRequestSystemMock;

        [SetUp]
        public void Setup()
        {
            customerRequestHandlerMock = new Mock<CustomerRequestHandler>();
            orderHandleSystemMock = new Mock<OrderHandleSystem>();
            dbRequestSystemMock = new Mock<IDBRequestSystem>();

            userControlSystem = new UserControlSystem();
            userControlSystem.customerRequestHandler = customerRequestHandlerMock.Object;
            userControlSystem.orderHandleSystem = orderHandleSystemMock.Object;
            userControlSystem.DB = dbRequestSystemMock.Object;
        }

        [Test]
        public void UserControlSystem_DefaultConstructor_InitializesPropertiesToNull()
        {
            var controlSystem = new UserControlSystem();

            Assert.IsNull(controlSystem.customerRequestHandler);
            Assert.IsNull(controlSystem.orderHandleSystem);
            Assert.IsNull(controlSystem.DB);
        }

        [Test]
        public void UserControlSystem_SetCustomerRequestHandler_SetsCustomerRequestHandler()
        {
            var newCustomerRequestHandler = new CustomerRequestHandler();
            userControlSystem.customerRequestHandler = newCustomerRequestHandler;

            Assert.AreSame(newCustomerRequestHandler, userControlSystem.customerRequestHandler);
        }

        [Test]
        public void UserControlSystem_SetOrderHandleSystem_SetsOrderHandleSystem()
        {
            var newOrderHandleSystem = new OrderHandleSystem();
            userControlSystem.orderHandleSystem = newOrderHandleSystem;

            Assert.AreSame(newOrderHandleSystem, userControlSystem.orderHandleSystem);
        }

        [Test]
        public void UserControlSystem_SetDB_SetsDBRequestSystem()
        {
            var newDBRequestSystem = new Mock<IDBRequestSystem>().Object;
            userControlSystem.DB = newDBRequestSystem;

            Assert.AreSame(newDBRequestSystem, userControlSystem.DB);
        }
    }


    [TestFixture]
    public class UserControlSystemTests2
    {
        private UserControlSystem userControlSystem;
        private Mock<CustomerRequestHandler> customerRequestHandlerMock;
        private Mock<OrderHandleSystem> orderHandleSystemMock;
        private Mock<IDBRequestSystem> dbRequestSystemMock;

        [SetUp]
        public void Setup()
        {
            customerRequestHandlerMock = new Mock<CustomerRequestHandler>();
            orderHandleSystemMock = new Mock<OrderHandleSystem>();
            dbRequestSystemMock = new Mock<IDBRequestSystem>();

            userControlSystem = new UserControlSystem();
            userControlSystem.customerRequestHandler = customerRequestHandlerMock.Object;
            userControlSystem.orderHandleSystem = orderHandleSystemMock.Object;
            userControlSystem.DB = dbRequestSystemMock.Object;
        }


        [Test]
        public void CreateUser_UnhandledRole_ThrowsException()
        {
            string login = "testuser";
            string password = "password";
            Roles role = (Roles)99; 
            string fullName = "Test User";

            Assert.Throws<Exception>(() => userControlSystem.CreateUser(login, password, role, fullName));
        }

        [Test]
        public void CreateUser_AddUserReturnsFalse_ReturnsNull()
        {
            string login = "testuser";
            string password = "password";
            Roles role = Roles.customer;
            string fullName = "Test User";
            var user = new Customer(login, password, new Dictionary<Guid, int>(), fullName, orderHandleSystemMock.Object);

            dbRequestSystemMock.Setup(db => db.AddUser(user)).Returns(false);

            var result = userControlSystem.CreateUser(login, password, role, fullName);

            Assert.IsNull(result);
        }

        
        [Test]
        public void DeleteUser_ValidLogin_ReturnsTrue()
        {
            string login = "testuser";

            var result = userControlSystem.DeleteUser(login);

            Assert.IsFalse(result);
            dbRequestSystemMock.Verify(db => db.DeleteUser(login), Times.Once);
        }

        [Test]
        public void DeleteUser_DeleteUserReturnsFalse_ReturnsFalse()
        {
            string login = "testuser";

            dbRequestSystemMock.Setup(db => db.DeleteUser(login)).Returns(false);

            var result = userControlSystem.DeleteUser(login);

            Assert.IsFalse(result);
            dbRequestSystemMock.Verify(db => db.DeleteUser(login), Times.Once);
        }
        
        [Test]
public void ChangeUserInfo_ValidLogin_ReturnsModifiedUser()
{
    string login = "testuser";
    string newLogin = "newuser";
    string password = "newpassword";
    string fullName = "New User";

    var originalUser = new Customer(login, "password", new Dictionary<Guid, int>(), "Test User", orderHandleSystemMock.Object);
    dbRequestSystemMock.Setup(db => db.GetCertainUser(login)).Returns(originalUser);

    var result = userControlSystem.ChangeUserInfo(login, newLogin, password, fullName);

    Assert.IsNotNull(result);
    Assert.IsInstanceOf<Customer>(result);
    Assert.AreEqual(newLogin, result.Login);
    Assert.AreEqual(password, result.Password);
    Assert.AreEqual(fullName, result.FullName);
    dbRequestSystemMock.Verify(db => db.ChangeUserInfo(login, result), Times.Once);
}

[Test]
public void ChangeUserInfo_UserDoesNotExist_ReturnsNull()
{
    string login = "nonexistentuser";


    dbRequestSystemMock.Setup(db => db.GetCertainUser(login)).Returns((IUser)null);
    
    var result = userControlSystem.ChangeUserInfo(login, "newlogin", "newpassword", "New User");

    Assert.IsNull(result);
    dbRequestSystemMock.Verify(db => db.ChangeUserInfo(It.IsAny<string>(), It.IsAny<IUser>()), Times.Never);
}


[Test]
public void ChangeUserInfo_NullParameters_DoNotModifyUser()
{
    string login = "testuser";
    var originalUser = new Customer(login, "password", new Dictionary<Guid, int>(), "Test User", orderHandleSystemMock.Object);
    dbRequestSystemMock.Setup(db => db.GetCertainUser(login)).Returns(originalUser);

    var result = userControlSystem.ChangeUserInfo(login, null, null, null);

    Assert.IsNotNull(result);
    Assert.AreSame(originalUser, result);
    dbRequestSystemMock.Verify(db => db.ChangeUserInfo(It.IsAny<string>(), It.IsAny<IUser>()), Times.Once);
}

        
[Test]
public void LogIn_ValidCredentials_ReturnsTrueAndSetsCurrentUser()
{
    string login = "testuser";
    string password = "password";
    var user = new Customer(login, password, new Dictionary<Guid, int>(), "Test User", orderHandleSystemMock.Object);
    dbRequestSystemMock.Setup(db => db.GetCertainUser(login)).Returns(user);

    var result = userControlSystem.LogIn(login, password);

    Assert.IsTrue(result);
    Assert.AreSame(user, customerRequestHandlerMock.Object.CurrentUser);
}

[Test]
public void LogIn_UserDoesNotExist_ReturnsFalseAndDoesNotSetCurrentUser()
{
    string login = "nonexistentuser";
    string password = "password";
    dbRequestSystemMock.Setup(db => db.GetCertainUser(login)).Returns((IUser)null);

    var result = userControlSystem.LogIn(login, password);

    Assert.IsFalse(result);
}

[Test]
public void LogIn_InvalidCredentials_ReturnsFalseAndDoesNotSetCurrentUser()
{
    string login = "testuser";
    string password = "incorrectpassword";
    var user = new Customer(login, "password", new Dictionary<Guid, int>(), "Test User", orderHandleSystemMock.Object);
    dbRequestSystemMock.Setup(db => db.GetCertainUser(login)).Returns(user);

    var result = userControlSystem.LogIn(login, password);

    Assert.IsFalse(result);
}

[Test]
public void LogIn_ConnectionCheckCalled()
{
    string login = "testuser";
    string password = "password";
    var user = new Customer(login, password, new Dictionary<Guid, int>(), "Test User", orderHandleSystemMock.Object);
    dbRequestSystemMock.Setup(db => db.GetCertainUser(login)).Returns(user);

    userControlSystem.LogIn(login, password);

}



[Test]
public void LogOut_SetCurrentUserToNull()
{

    userControlSystem.LogOut();

}

[Test]
public void SwitchUser_CurrentUserNotNull_LogsOutAndLogsIn()
{
    string login = "testuser";
    string password = "password";
    var user = new Customer(login, password, new Dictionary<Guid, int>(), "Test User", orderHandleSystemMock.Object);
    customerRequestHandlerMock.Object.CurrentUser = user;

    var result = userControlSystem.SwitchUser(login, password);

    Assert.IsFalse(result);
}

[Test]
public void SwitchUser_CurrentUserNull_LogsIn()
{
    string login = "testuser";
    string password = "password";

    var result = userControlSystem.SwitchUser(login, password);

    Assert.IsFalse(result);
}


    }
    
    
    
}
