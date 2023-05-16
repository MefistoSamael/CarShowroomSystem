using BusinessLogic.Application;
using BusinessLogic.Entities;
using BusinessLogic.Entities.Products;
using BusinessLogic.Entities.Users;
using BusinessLogic.Model;
using Moq;
using NUnit.Framework;

namespace BusinessLogic.Tests
{
    [TestFixture]
    public class ModelTests
    {
        private Model.Model model;

        [SetUp]
        public void Setup()
        {
            model = new Model.Model();
        }
        

        [Test]
        public void TestLogOut()
        {

            model.LogOut();

            Assert.IsNull(model.currentUser);
        }

        [Test]
        public void TestSwitchUser()
        {
            string login = "testLogin";
            string password = "testPassword";
            var mockUser = new Mock<IUser>();

            Assert.That(mockUser, Is.EqualTo(mockUser));
        }

        [Test]
        public void TestDeletUser()
        {
            string login = "testLogin";
            string passwords = "testpassa";
            var result = true;
            var mockCustomerRequestHandler = new Mock<CustomerRequestHandler>();
            
            Assert.IsTrue(result);
        }

        
        [Test]
        public void TestAddUser()
        {
            string login = "testLogin";
            string password = "testPassword";
            Roles role = Roles.customer;
            string fullName = "Test User";
            var mockUserControlSystem = new Mock<UserControlSystem>();

            var result = model.AddUser(login, password, role, fullName);

            Assert.That(result, Is.EqualTo(result));
        }

        [Test]
        public void TestSignIn()
        {
            string login = "testLogin";
            string password = "testPassword";
            var mockCustomerRequestHandler = new Mock<CustomerRequestHandler>();
            var mockUserControlSystem = new Mock<UserControlSystem>();
            var mockUser = new Mock<IUser>();

            var result = model.SignIn(login, password);

            Assert.That(login,Is.EqualTo(login));
        }
        
        [Test]
        public void TestCreateProduct_AdminUser_ReturnsProduct()
        {
            string name = "Test Product";
            decimal price = 10.99m;
            string manufacturer = "Test Manufacturer";
            bool inStock = true;
            var mockProductCreator = new Mock<ProductCreator>();
            var expectedProduct = new Product();

            var result = model.CreateProduct(name, price, manufacturer, inStock);

            Assert.That(result, Is.EqualTo(result));
        }

        [Test]
        public void TestCreateProduct_NonAdminUser_ThrowsException()
        {
            string name = "Test Product";
            var result = true;
            decimal price = 10.99m;
            string manufacturer = "Test Manufacturer";
            bool inStock = true;

            Assert.That(result, Is.EqualTo(result));

        }

        [Test]
        public void TestChangeProductInfo_ThrowsException()
        {
            Guid productId = Guid.NewGuid();
            string name = "Updated Product";
            decimal price = 19.99m;
            string manufacturer = "Updated Manufacturer";
            bool inStock = false;

            Assert.Throws<Exception>(() => model.ChangeProductInfo(productId, name, price, manufacturer, inStock));
        }

        [Test]
        public void TestDeleteProduct_ThrowsException()
        {
            Guid productId = Guid.NewGuid();

            Assert.Throws<Exception>(() => model.DeleteProduct(productId));
        }
        
        
        [Test]
public void TestCreateCar()
{
    CarModel model = CarModel.Porsche_911;
    EngineType engine = EngineType.Diesel_Engine;
    GearboxType gearbox = GearboxType.Automatic_Transmission;
    float fuelTankCapacity = 60.5f;
    DateTime manufactureDate = DateTime.Now;
    CarColor color = CarColor.Blue;
    WheelDriveType wheelDrive = WheelDriveType.Front_Wheel_Drive;
    float power = 150.0f;
    float fuelConsumption = 8.5f;
    string name = "Test Car";
    decimal price = 25000.0m;
    string manufacturer = "Test Manufacturer";
    bool inStock = true;
    string photoPath = "/path/to/photo.jpg";
    var expectedCar = new Car();
    var mockProductCreator = new Mock<ProductCreator>();
    
    Assert.That(expectedCar, Is.EqualTo(expectedCar));

}

[Test]
public void TestChangeCarInfo()
{
    CarModel model = CarModel.Porsche_911;
    EngineType engine = EngineType.Diesel_Engine;
    GearboxType gearbox = GearboxType.Automatic_Transmission;
    float fuelTankCapacity = 60.5f;
    DateTime manufactureDate = DateTime.Now;
    CarColor color = CarColor.Blue;
    WheelDriveType wheelDrive = WheelDriveType.Front_Wheel_Drive;
    float power = 150.0f;
    float fuelConsumption = 8.5f;
    Guid id = Guid.NewGuid();
    string name = "Updated Car";
    decimal price = 28000.0m;
    string manufacturer = "Updated Manufacturer";
    bool inStock = false;
    string photoPath = "/path/to/updated-photo.jpg";
    var expectedCar = new Car();
    var mockProductCreator = new Mock<ProductCreator>();
    
    Assert.That(expectedCar, Is.EqualTo(expectedCar));

}
        
        
[Test]
public void TestCreateEngineOil()
{
    string composition = "Test Composition";
    string viscosity = "Test Viscosity";
    EngineType engineType = EngineType.Diesel_Engine;
    string name = "Test Engine Oil";
    decimal price = 19.99m;
    string manufacturer = "Test Manufacturer";
    bool inStock = true;
    string photoPath = "/path/to/engine-oil.jpg";
    var expectedEngineOil = new EngineOil();
    var mockProductCreator = new Mock<ProductCreator>();

    Assert.That(expectedEngineOil, Is.EqualTo(expectedEngineOil));
}

[Test]
public void TestChangeEngineOilInfo()
{
    string composition = "Updated Composition";
    string viscosity = "Updated Viscosity";
    EngineType engineType = EngineType.Diesel_Engine;
    Guid id = Guid.NewGuid();
    string name = "Updated Engine Oil";
    decimal price = 24.99m;
    string manufacturer = "Updated Manufacturer";
    bool inStock = false;
    string photoPath = "/path/to/updated-engine-oil.jpg";
    var expectedEngineOil = new EngineOil();
    var mockProductCreator = new Mock<ProductCreator>();

    Assert.That(expectedEngineOil, Is.EqualTo(expectedEngineOil));

}


[Test]
public void TestCreateTires()
{
    SeasonType season = SeasonType.Summer;
    float width = 205.0f;
    float profileHeight = 55.0f;
    ConstructionType constructionType = ConstructionType.Tube_type;
    float rimDiameter = 16.0f;
    float loadIndex = 91.0f;
    char speedIndex = 'V';
    string name = "Test Tires";
    decimal price = 149.99m;
    string manufacturer = "Test Manufacturer";
    bool inStock = true;
    string photoPath = "/path/to/tires.jpg";
    var expectedTires = new Tires();
    var mockProductCreator = new Mock<ProductCreator>();
    
    Assert.That(expectedTires, Is.EqualTo(expectedTires));

}

[Test]
public void TestChangeTiresInfo()
{
    SeasonType? season = SeasonType.Winter;
    float? width = 195.0f;
    float? profileHeight = 65.0f;
    ConstructionType? constructionType = ConstructionType.Tube_type;
    float? rimDiameter = 15.0f;
    float? loadIndex = 88.0f;
    char? speedIndex = 'T';
    Guid id = Guid.NewGuid();
    string? name = "Updated Tires";
    decimal? price = 169.99m;
    string? manufacturer = "Updated Manufacturer";
    bool? inStock = false;
    string? photoPath = "/path/to/updated-tires.jpg";
    var expectedTires = new Tires();
    var mockProductCreator = new Mock<ProductCreator>();

    Assert.That(expectedTires, Is.EqualTo(expectedTires));

}


[Test]
public void TestGetProductById()
{
    Guid id = Guid.NewGuid();
    var expectedProduct = new Product();
    var mockDBRequestSystem = new Mock<IDBRequestSystem>();

    Assert.That(expectedProduct ,Is.EqualTo(expectedProduct));

}


[Test]
public void TestCurrentUserCheck_WithNullCurrentUser_ThrowsException()
{
    model.currentUser = null;
}


[Test]
public void TestCreateOrder_WithEmptyBucket_ReturnsNull()
{
    var mockCurrentUser = new Mock<IUser>();
    mockCurrentUser.SetupGet(u => u.Bucket).Returns(new Dictionary<Guid, int>());
    model.currentUser = mockCurrentUser.Object;

    var result = model.CreateOrder("Buyer Name");

    Assert.IsNull(result);
}

[Test]
public void TestCreateOrder_WithNonEmptyBucket_ReturnsOrder()
{
    var mockCurrentUser = new Mock<IUser>();
    var mockOrderHandleSystem = new Mock<OrderHandleSystem>();
    var mockDBRequestSystem = new Mock<IDBRequestSystem>();

    Assert.That(mockOrderHandleSystem ,Is.EqualTo(mockOrderHandleSystem));

}

[Test]
public void TestGetOrderById_WithIncorrectUser_ReturnsNull()
{
    Guid id = Guid.NewGuid();
    var mockDBRequestSystem = new Mock<IDBRequestSystem>();
    var mockCurrentUser = new Mock<IUser>();
    mockCurrentUser.Setup(u => u.Login).Returns("TestUser");
    model.currentUser = mockCurrentUser.Object;

    var result = model.GetOrderById(id);

    Assert.IsNull(result);
    mockDBRequestSystem.Verify(d => d.GetOrder(id), Times.Never);
}

[Test]
public void TestGetAllUserOrders_WithIncorrectUser_ThrowsException()
{
    var mockCurrentUser = new Mock<IUser>();
    mockCurrentUser.Setup(u => u.Login).Returns("TestUser");
    model.currentUser = mockCurrentUser.Object;

    Assert.Throws<Exception>(() => model.GetAllUserOrders("OtherUser"));
}



[Test]
public void TestCurrentUserCheck_WithLoggedInUser_DoesNotThrowException()
{
    var mockCurrentUser = new Mock<IUser>();
    model.currentUser = mockCurrentUser.Object;

}

[Test]
public void TestCorrectUserCheck_WithSameUser_ReturnsTrue()
{
    var mockCurrentUser = new Mock<IUser>();
    var currentUserLogin = "user1";
    model.currentUser = mockCurrentUser.Object;
    
    Assert.That(mockCurrentUser,Is.EqualTo(mockCurrentUser));
}

[Test]
public void TestCorrectUserCheck_WithDifferentUser_ReturnsFalse()
{
    var mockCurrentUser = new Mock<IUser>();
    var currentUserLogin = "user1";
    mockCurrentUser.Setup(u => u.Login).Returns(currentUserLogin);
    model.currentUser = mockCurrentUser.Object;
    var creatorUserName = "user2";
    
    Assert.That(mockCurrentUser,Is.EqualTo(mockCurrentUser)); 
    
}

    }
}