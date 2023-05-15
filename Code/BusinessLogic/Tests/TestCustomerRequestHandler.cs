namespace BusinessLogic.Application.Tests;

using BusinessLogic.Entities.Users;
using BusinessLogic.Application;

using Moq;


[TestFixture]
public class TestCustomerRequestHandler
{
    [Test]
    public void Constructor_InitializeCurrentUserToNull()
    {
        // Arrange
        var handler = new CustomerRequestHandler();

        // Act

        // Assert
        Assert.IsNull(handler.CurrentUser);
    }

    [Test]
    public void Constructor_InitializeUserControlSystemToNull()
    {
        // Arrange
        var handler = new CustomerRequestHandler();

        // Act

        // Assert
        Assert.IsNull(handler.userControlSystem);
    }
    
    
    [Test]
    public void CreateOrder_WhenCurrentUserIsNotSet_ThrowsException()
    {
        // Arrange
        var handler = new CustomerRequestHandler();

        // Act
        TestDelegate createOrderDelegate = () => handler.CreateOrder("Buyer Full Name");

        // Assert
        Assert.Throws<Exception>(createOrderDelegate); // Replace SomeException with the appropriate exception type expected to be thrown
    }
    
    [Test]
    public void CancelOrder_WhenCurrentUserIsNotSet_ThrowsException()
    {
        // Arrange
        var handler = new CustomerRequestHandler();

        // Act
        TestDelegate cancelOrderDelegate = () => handler.CancelOrder(Guid.NewGuid());

        // Assert
        Assert.Throws<Exception>(cancelOrderDelegate); // Replace SomeException with the appropriate exception type expected to be thrown
    }

    
    [TestFixture]
    public class CustomerRequestHandlerTests
    {
        private Mock<IUser> mockUser;
        private CustomerRequestHandler handler;

        [SetUp]
        public void Setup()
        {
            // Arrange
            mockUser = new Mock<IUser>();
            handler = new CustomerRequestHandler();
            handler.CurrentUser = mockUser.Object;
        }

        [Test]
        public void CreateOrder_UserCheckCalled()
        {
            // Act
            var result = handler.CreateOrder("Buyer Name");

            // Assert
            mockUser.Verify(u => u.CreateOrder("Buyer Name"), Times.Once);
        }

        [Test]
        public void CancelOrder_UserCheckCalled()
        {
            // Act
            var result = handler.CancelOrder(Guid.NewGuid());

            // Assert
            mockUser.Verify(u => u.CancelOrder(It.IsAny<Guid>()), Times.Once);
        }
    }
    
    
    
}
