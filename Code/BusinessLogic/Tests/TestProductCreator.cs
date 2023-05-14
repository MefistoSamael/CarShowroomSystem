using BusinessLogic.Application;
using BusinessLogic.Entities.Products;

using Moq;



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
        
        
    [Test]
    public void CreateCar_AddsCarToDB()
    {
        var creator = new ProductCreator();
        var carModel = CarModel.Toyota_Corolla;
        var engineType = EngineType.Electric_Motor;
        var gearboxType = GearboxType.Automatic_Transmission;
        var fuelTankCapacity = 50f;
        var manufactureDate = new DateTime(2023, 5, 14);
        var carColor = CarColor.Black;
        var wheelDriveType = WheelDriveType.Front_Wheel_Drive;
        var power = 150f;
        var fuelConsumption = 10f;
        var name = "q";
        var price = 90000M;
        var manufacturer = "q";
        var inStock = true;
        var photoPath = "a";

        var result = creator.CreateCar(carModel, engineType, gearboxType, fuelTankCapacity, manufactureDate, carColor, wheelDriveType, power, fuelConsumption, name, price, manufacturer, inStock, photoPath);

        _mockDb?.Verify(x => x.AddProduct(result), Times.Once);
    }

    [Test]
    public void CreateCar_ReturnsCarWithCorrectValues()
    {
        var creator = new ProductCreator();
        var carModel = CarModel.Jeep_Wrangler;
        var engineType = EngineType.Gasoline_Engine;
        var gearboxType = GearboxType.SemiAutomatic_Transmission;
        var fuelTankCapacity = 50f;
        var manufactureDate = new DateTime(2023, 5, 14);
        var carColor = CarColor.Blue;
        var wheelDriveType = WheelDriveType.Rear_Wheel_Drive;
        var power = 150f;
        var fuelConsumption = 10f;
        var name = "18980c1892c07j7818279tde12yQQQQQQQQQQQQQQQQQQQQQQQQQQ92/c:::e762yetfvi87!@&*O(*CT!@YHIVYU!O@H*YVIOY*QQQQQqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqetfvi871h92i";
        var price = 90000M;
        var manufacturer = "q%!^&@*$^URCYT@92/c:::e762yetfvi87!@&*O(*CT!@YHIVYU!O@H*YVIOY*!Uiyufc1i2b";
        var inStock = true;
        var photoPath = "192/c:::e768////!(@&*O^ICGT92/c:::e762yetfvi87!@&*O(*CT!@YHIVYU!O@H*YVIOY*!@//1g//::://29c.jpg.jpg";

        var result = creator.CreateCar(carModel, engineType, gearboxType, fuelTankCapacity, manufactureDate, carColor, wheelDriveType, power, fuelConsumption, name, price, manufacturer, inStock, photoPath);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(carModel, result.Model);
        Assert.AreEqual(engineType, result.Engine);
        Assert.AreEqual(gearboxType, result.Gearbox);
        Assert.AreEqual(fuelTankCapacity, result.FuelTankCapacity);
        Assert.AreEqual(manufactureDate, result.ManufactureDate);
        Assert.AreEqual(carColor, result.Color);
        Assert.AreEqual(wheelDriveType, result.WheelDrive);
        Assert.AreEqual(power, result.Power);
        Assert.AreEqual(fuelConsumption, result.FuelConsumption);
        Assert.AreEqual(name, result.Name);
        Assert.AreEqual(price, result.Price);
        Assert.AreEqual(manufacturer, result.Manufacturer);
        Assert.AreEqual(inStock, result.InStock);
        Assert.AreEqual(photoPath, result.PhotoPath);
    }
}
    
}