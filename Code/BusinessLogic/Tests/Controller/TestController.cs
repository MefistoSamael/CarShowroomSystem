using BusinessLogic.Controller;
using BusinessLogic.Entities.Products;
using BusinessLogic.Entities.Users;
using BusinessLogic.Model;
using Moq;
using NUnit.Framework;

namespace BusinessLogic.Tests.Controller
{
    [TestFixture]
    public class ControllerTests
    {
        private Mock<IModel> mockModel;
        private BusinessLogic.Controller.Controller controller;

        [SetUp]
        public void Setup()
        {
            mockModel = new Mock<IModel>();
            controller = new BusinessLogic.Controller.Controller(mockModel.Object);
        }

        [Test]
        public void Controller_Constructor_WithValidModel_AssignsModel()
        {
            IModel model = mockModel.Object;

            BusinessLogic.Controller.Controller controller = new BusinessLogic.Controller.Controller(model);

            Assert.AreEqual(model, model);
        }
        
        
        [Test]
        public void SignUp_WithValidArguments_ReturnsTrue()
        {
            string login = "testuser";
            string password = "password";
            Roles role = Roles.customer;
            string fullName = "Test User";

            bool result = controller.SignUp(login, password, role, fullName);

            Assert.IsFalse(result);
        }

        [Test]
        public void SignUp_WithInvalidArguments_ReturnsFalse()
        {
            string login = "testuser";
            string password = "password";
            Roles role = Roles.customer;
            string fullName = "Test User";

            bool result = controller.SignUp(login, password, role, fullName);

            Assert.IsFalse(result);
        }


        [Test]
        public void SignIn_WithInvalidCredentials_ReturnsNull()
        {
            string login = "testuser";
            string password = "password";

            mockModel.Setup(m => m.SignIn(login, password)).Returns((IUser)null);

            IUser? result = controller.SignIn(login, password);

            Assert.IsNull(result);
        }

[Test]
public void CreateProduct_WithValidArguments_ReturnsProduct()
{
    string name = "Test Product";
    decimal price = 10.99m;
    string manufacturer = "Test Manufacturer";
    bool inStock = true;
    Product expectedProduct = new Product();

    mockModel.Setup(m => m.CreateProduct(name, price, manufacturer, inStock)).Returns(expectedProduct);

    Product? result = controller.CreateProduct(name, price, manufacturer, inStock);

    Assert.AreEqual(expectedProduct, result);
}

[Test]
public void ChangeProductInfo_WithValidArguments_ReturnsProduct()
{
    Guid id = Guid.NewGuid();
    string name = "Updated Product";
    decimal price = 19.99m;
    string manufacturer = "Updated Manufacturer";
    bool inStock = false;
    Product expectedProduct = new Product();

    mockModel.Setup(m => m.ChangeProductInfo(id, name, price, manufacturer, inStock)).Returns(expectedProduct);

    Product? result = controller.ChangeProductInfo(id, name, price, manufacturer, inStock);

    Assert.AreEqual(expectedProduct, result);
}

[Test]
public void DeleteProduct_WithValidId_ReturnsTrue()
{
    Guid id = Guid.NewGuid();

    mockModel.Setup(m => m.DeleteProduct(id)).Returns(true);

    bool result = controller.DeleteProduct(id);

    Assert.IsTrue(result);
}

[Test]
public void DeleteProduct_WithInvalidId_ReturnsFalse()
{
    Guid id = Guid.NewGuid();

    mockModel.Setup(m => m.DeleteProduct(id)).Returns(false);

    bool result = controller.DeleteProduct(id);

    Assert.IsFalse(result);
}

[Test]
public void GetAllProducts_ReturnsListOfProducts()
{
    List<Product> expectedProducts = new List<Product>() { new Product(), new Product() };

    mockModel.Setup(m => m.GetAllProducts()).Returns(expectedProducts);

    List<Product> result = controller.GetAllProducts();

    Assert.AreEqual(expectedProducts, result);
}

[Test]
public void GetProductById_WithValidId_ReturnsProduct()
{
    Guid id = Guid.NewGuid();
    Product expectedProduct = new Product();

    mockModel.Setup(m => m.GetProductById(id)).Returns(expectedProduct);

    Product? result = controller.GetProductById(id);

    Assert.AreEqual(expectedProduct, result);
}

[Test]
public void GetProductById_WithInvalidId_ReturnsNull()
{
    Guid id = Guid.NewGuid();

    mockModel.Setup(m => m.GetProductById(id)).Returns((Product)null);

    Product? result = controller.GetProductById(id);

    Assert.IsNull(result);
}

[Test]
public void DeleteUser_WithValidLogin_ReturnsTrue()
{
    string login = "testuser";

    mockModel.Setup(m => m.DeleteUser(login)).Returns(true);

    bool result = controller.DeleteUser(login);

    Assert.IsTrue(result);
}

[Test]
public void DeleteUser_WithInvalidLogin_ReturnsFalse()
{
    string login = "testuser";

    mockModel.Setup(m => m.DeleteUser(login)).Returns(false);

    bool result = controller.DeleteUser(login);

    Assert.IsFalse(result);
}

[Test]
public void GetCertainUser_WithInvalidLogin_ReturnsNull()
{
    string login = "testuser";

    mockModel.Setup(m => m.GetCertainUser(login)).Returns((IUser)null);

    IUser? result = controller.GetCertainUser(login);

    Assert.IsNull(result);
}

        
        [Test]
public void CreateCar_WithValidArguments_ReturnsCar()
{
    CarModel model = CarModel.Porsche_911;
    EngineType engine = EngineType.Diesel_Engine;
    GearboxType gearbox = GearboxType.Automatic_Transmission;
    float fuelTankCapacity = 50.0f;
    DateTime manufactureDate = new DateTime(2022, 1, 1);
    CarColor color = CarColor.Red;
    WheelDriveType wheelDrive = WheelDriveType.Front_Wheel_Drive;
    float power = 150.0f;
    float fuelConsumption = 8.5f;
    string name = "Test Car";
    decimal price = 25000.0m;
    string manufacturer = "Test Manufacturer";
    bool inStock = true;
    string photoPath = "test/photo.jpg";
    Car expectedCar = new Car();

    mockModel.Setup(m => m.CreateCar(model, engine, gearbox, fuelTankCapacity, manufactureDate, color, wheelDrive, power, fuelConsumption, name, price, manufacturer, inStock, photoPath)).Returns(expectedCar);

    Car result = controller.CreateCar(model, engine, gearbox, fuelTankCapacity, manufactureDate, color, wheelDrive, power, fuelConsumption, name, price, manufacturer, inStock, photoPath);

    Assert.AreEqual(expectedCar, result);
}

[Test]
public void ChangeCarInfo_WithValidArguments_ReturnsCar()
{
    CarModel model = CarModel.Porsche_911;
    EngineType engine = EngineType.Diesel_Engine;
    GearboxType gearbox = GearboxType.Automatic_Transmission;
    float fuelTankCapacity = 60.0f;
    DateTime manufactureDate = new DateTime(2023, 1, 1);
    CarColor color = CarColor.Blue;
    WheelDriveType wheelDrive = WheelDriveType.Front_Wheel_Drive;
    float power = 180.0f;
    float fuelConsumption = 9.5f;
    Guid id = Guid.NewGuid();
    string name = "Updated Car";
    decimal price = 30000.0m;
    string manufacturer = "Updated Manufacturer";
    bool inStock = false;
    string photoPath = "test/updated_photo.jpg";
    Car expectedCar = new Car();

    mockModel.Setup(m => m.ChangeCarInfo(model, engine, gearbox, fuelTankCapacity, manufactureDate, color, wheelDrive, power, fuelConsumption, id, name, price, manufacturer, inStock, photoPath)).Returns(expectedCar);
    
    Car? result = controller.ChangeCarInfo(model, engine, gearbox, fuelTankCapacity, manufactureDate, color, wheelDrive, power, fuelConsumption, id, name, price, manufacturer, inStock, photoPath);

    Assert.AreEqual(expectedCar, result);
}

[Test]
public void CreateEngineOil_WithValidArguments_ReturnsEngineOil()
{
    string composition = "Synthetic";
    string viscosity = "10W-40";
    EngineType engineType = EngineType.Electric_Motor;
    string name = "Test Engine Oil";
    decimal price = 29.99m;
    string manufacturer = "Test Manufacturer";
    bool inStock = true;
    string photoPath = "test/engineoil_photo.jpg";
    EngineOil expectedEngineOil = new EngineOil();

    mockModel.Setup(m => m.CreateEngineOil(composition, viscosity, engineType, name, price, manufacturer, inStock, photoPath)).Returns(expectedEngineOil);

    EngineOil result = controller.CreateEngineOil(composition, viscosity, engineType, name, price, manufacturer, inStock, photoPath);

    Assert.AreEqual(expectedEngineOil, result);
}

[Test]
public void ChangeEngineOilInfo_WithValidArguments_ReturnsEngineOil()
{
    string composition = "Semi-Synthetic";
    string viscosity = "5W-30";
    EngineType engineType = EngineType.Diesel_Engine;
    Guid id = Guid.NewGuid();
    string name = "Updated Engine Oil";
    decimal price = 39.99m;
    string manufacturer = "Updated Manufacturer";
    bool inStock = false;
    string photoPath = "test/updated_engineoil_photo.jpg";
    EngineOil expectedEngineOil = new EngineOil();

    mockModel.Setup(m => m.ChangeEngineOilInfo(composition, viscosity, engineType, id, name, price, manufacturer, inStock, photoPath)).Returns(expectedEngineOil);

    EngineOil? result = controller.ChangeEngineOilInfo(composition, viscosity, engineType, id, name, price, manufacturer, inStock, photoPath);

    Assert.AreEqual(expectedEngineOil, result);
}


[Test]
public void CreateTires_WithValidArguments_ReturnsTires()
{
    SeasonType season = SeasonType.Summer;
    float width = 205.0f;
    float profileHeight = 55.0f;
    ConstructionType constructionType = ConstructionType.Bias;
    float rimDiameter = 16.0f;
    float loadIndex = 91.0f;
    char speedIndex = 'H';
    string name = "Test Tires";
    decimal price = 149.99m;
    string manufacturer = "Test Manufacturer";
    bool inStock = true;
    string photoPath = "test/tires_photo.jpg";
    Tires expectedTires = new Tires();

    mockModel.Setup(m => m.CreateTires(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, name, price, manufacturer, inStock, photoPath)).Returns(expectedTires);

    Tires result = controller.CreateTires(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, name, price, manufacturer, inStock, photoPath);

    Assert.AreEqual(expectedTires, result);
}

[Test]
public void ChangeTiresInfo_WithValidArguments_ReturnsTires()
{
    SeasonType season = SeasonType.Winter;
    float width = 195.0f;
    float profileHeight = 65.0f;
    ConstructionType constructionType = ConstructionType.All_Season;
    float rimDiameter = 15.0f;
    float loadIndex = 89.0f;
    char speedIndex = 'T';
    Guid id = Guid.NewGuid();
    string name = "Updated Tires";
    decimal price = 169.99m;
    string manufacturer = "Updated Manufacturer";
    bool inStock = false;
    string photoPath = "test/updated_tires_photo.jpg";
    Tires expectedTires = new Tires();

    mockModel.Setup(m => m.ChangeTiresInfo(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, id, name, price, manufacturer, inStock, photoPath)).Returns(expectedTires);

    Tires? result = controller.ChangeTiresInfo(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, id, name, price, manufacturer, inStock, photoPath);

    Assert.AreEqual(expectedTires, result);
}

        
        
    }
}