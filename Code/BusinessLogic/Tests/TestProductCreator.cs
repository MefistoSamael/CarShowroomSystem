using BusinessLogic.Application;
using BusinessLogic.Entities.Products;

using Moq;

namespace BusinessLogic.Application.Tests
{

    [TestFixture]
    public class TestProductCreator
    {


        [TestFixture]
        public class CreateProduct
        {
            private ProductCreator _productCreator;
            private Mock<IDBRequestSystem> _dbMock;

            [SetUp]
            public void Setup()
            {
                _dbMock = new Mock<IDBRequestSystem>();
                _productCreator = new ProductCreator { db = _dbMock.Object };
            }

            [Test]
            public void CreateProduct_AddsProductToDatabase()
            {
                // Arrange
                var id = Guid.NewGuid();
                var name = "Test Product";
                var manufacturer = "Test Manufacturer";
                var inStock = true;
                var price = 9.99m;

                // Act
                var result = _productCreator.CreateProduct(id, name, manufacturer, inStock, price);

                // Assert
                _dbMock.Verify(x => x.AddProduct(It.IsAny<Product>()), Times.Once);
            }

            [Test]
            public void CreateProduct_ReturnsCreatedProduct()
            {
                // Arrange
                var id = Guid.NewGuid();
                var name = "Test Product";
                var manufacturer = "Test Manufacturer";
                var inStock = true;
                var price = 9.99m;

                // Act
                var result = _productCreator.CreateProduct(id, name, manufacturer, inStock, price);

                // Assert
                Assert.IsInstanceOf<Product>(result);
                Assert.AreEqual(id, result.Id);
                Assert.AreEqual(name, result.Name);
                Assert.AreEqual(manufacturer, result.Manufacturer);
                Assert.AreEqual(inStock, result.InStock);
                Assert.AreEqual(price, result.Price);
            }
        }


        [TestFixture]
        public class CreateCar
        {
            private ProductCreator _carCreator;
            private Mock<IDBRequestSystem> _dbMock;

            [SetUp]
            public void Setup()
            {
                _dbMock = new Mock<IDBRequestSystem>();
                _carCreator = new ProductCreator() { db = _dbMock.Object };
            }

            [Test]
            public void CreateCar_AddsCarToDatabase()
            {
                // Arrange
                var carModel = CarModel.Jeep_Wrangler;
                var engineType = EngineType.Gasoline_Engine;
                var gearboxType = GearboxType.SemiAutomatic_Transmission;
                var fuelTankCapacity = 60f;
                var manufactureDate = DateTime.Now;
                var carColor = CarColor.Black;
                var wheelDriveType = WheelDriveType.Rear_Wheel_Drive;
                var power = 150f;
                var fuelConsumption = 7.5f;
                var name = "Test Car";
                var price = 50000m;
                var manufacturer = "Test Manufacturer";
                var inStock = true;
                var photoPath = "/path/to/photo";

                // Act
                var result = _carCreator.CreateCar(carModel, engineType, gearboxType, fuelTankCapacity, manufactureDate,
                    carColor, wheelDriveType, power, fuelConsumption, name, price, manufacturer, inStock, photoPath);

                // Assert
                _dbMock.Verify(x => x.AddCar(It.IsAny<Car>()), Times.Once);
            }

            [Test]
            public void CreateCar_ReturnsCreatedCar()
            {
                // Arrange
                var carModel = CarModel.Jeep_Wrangler;
                var engineType = EngineType.Gasoline_Engine;
                var gearboxType = GearboxType.SemiAutomatic_Transmission;
                var fuelTankCapacity = 60f;
                var manufactureDate = DateTime.Now;
                var carColor = CarColor.Black;
                var wheelDriveType = WheelDriveType.Rear_Wheel_Drive;
                var power = 150f;
                var fuelConsumption = 7.5f;
                var name = "Test Car";
                var price = 50000m;
                var manufacturer = "Test Manufacturer";
                var inStock = true;
                var photoPath = "/path/to/photo";

                // Act
                var result = _carCreator.CreateCar(carModel, engineType, gearboxType, fuelTankCapacity, manufactureDate,
                    carColor, wheelDriveType, power, fuelConsumption, name, price, manufacturer, inStock, photoPath);

                // Assert
                Assert.IsInstanceOf<Car>(result);
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


        [TestFixture]
        public class CarManagerTests
        {
            private Mock<IDBRequestSystem> mockDb;
            private ProductCreator carManager;

            [SetUp]
            public void Setup()
            {
                mockDb = new Mock<IDBRequestSystem>();
                carManager = new ProductCreator() { db = mockDb.Object };
            }

            [Test]
            public void ChangeCarInfo_CarExists_ReturnsCar()
            {
                // Arrange
                var car = new Car
                {
                    Id = Guid.NewGuid(),
                    Model = CarModel.Toyota_Corolla,
                    Engine = EngineType.Electric_Motor,
                    Gearbox = GearboxType.Automatic_Transmission,
                    FuelTankCapacity = 50,
                    ManufactureDate = new DateTime(2020, 1, 1),
                    Color = CarColor.Black,
                    WheelDrive = WheelDriveType.Rear_Wheel_Drive,
                    Power = 300,
                    FuelConsumption = 10,
                    Name = "Car1",
                    Price = 20000,
                    Manufacturer = "Manufacturer1",
                    InStock = true,
                    PhotoPath = "/photos/car1.jpg"
                };

                mockDb.Setup(x => x.GetCar(car.Id)).Returns(car);

                // Act
                var result = carManager.ChangeCarInfo(CarModel.Toyota_Corolla, EngineType.Electric_Motor,
                    GearboxType.Automatic_Transmission, 60, new DateTime(2022, 1, 1), CarColor.Red,
                    WheelDriveType.Rear_Wheel_Drive, 250, 12, car.Id, "Car2", 25000, "Manufacturer2", false,
                    "/photos/car2.jpg");

                // Assert
                Assert.AreEqual(result, car);
                Assert.AreEqual(result.Model, CarModel.Toyota_Corolla);
                Assert.AreEqual(result.Engine, EngineType.Electric_Motor);
                Assert.AreEqual(result.Gearbox, GearboxType.Automatic_Transmission);
                Assert.AreEqual(result.FuelTankCapacity, 60);
                Assert.AreEqual(result.ManufactureDate, new DateTime(2022, 1, 1));
                Assert.AreEqual(result.Color, CarColor.Red);
                Assert.AreEqual(result.WheelDrive, WheelDriveType.Rear_Wheel_Drive);
                Assert.AreEqual(result.Power, 250);
                Assert.AreEqual(result.FuelConsumption, 12);
                Assert.AreEqual(result.Name, "Car2");
                Assert.AreEqual(result.Price, 25000);
                Assert.AreEqual(result.Manufacturer, "Manufacturer2");
                Assert.AreEqual(result.InStock, false);
                Assert.AreEqual(result.PhotoPath, "/photos/car2.jpg");
                mockDb.Verify(x => x.ChangeCarInfo(car.Id, result), Times.Once);
            }

            [Test]
            public void ChangeCarInfo_CarDoesNotExist_ReturnsNull()
            {
                // Arrange
                mockDb.Setup(x => x.GetCar(It.IsAny<Guid>())).Returns<Car>(null);

                // Act
                var result = carManager.ChangeCarInfo(CarModel.Toyota_Corolla, EngineType.Electric_Motor,
                    GearboxType.Automatic_Transmission, 60, new DateTime(2022, 1, 1), CarColor.Red,
                    WheelDriveType.Rear_Wheel_Drive, 250, 12, Guid.NewGuid(), "Car2", 25000, "Manufacturer2", false,
                    "/photos/car2.jpg");

                // Assert
                Assert.IsNull(result);
                mockDb.Verify(x => x.ChangeCarInfo(It.IsAny<Guid>(), It.IsAny<Car>()), Times.Never);
            }
        }

        [TestFixture]
        public class EngineOilTests
        {
            [Test]
            public void CreateEngineOil_AddsToDatabase()
            {
                // Arrange
                string composition = "synthetic";
                string viscosity = "5W-30";
                EngineType engineType = EngineType.Gasoline_Engine;
                string name = "Example Engine Oil";
                decimal price = 29.99M;
                string manufacturer = "Example Manufacturer";
                bool inStock = true;
                string photoPath = "/example/photo.jpg";

                var mockDb = new Mock<IDBRequestSystem>();
                var engineOil = new EngineOil();

                mockDb.Setup(db => db.AddEngineOil(It.IsAny<EngineOil>()))
                    .Callback<EngineOil>(oil => engineOil = oil);

                var engineOilService = new ProductCreator() { db = mockDb.Object };

                // Act
                var result = engineOilService.CreateEngineOil(composition, viscosity, engineType, name, price,
                    manufacturer, inStock, photoPath);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(engineOil.Composition, composition);
                Assert.AreEqual(engineOil.Viscosity, viscosity);
                Assert.AreEqual(engineOil.EngineType, engineType);
                Assert.AreEqual(engineOil.Name, name);
                Assert.AreEqual(engineOil.Price, price);
                Assert.AreEqual(engineOil.Manufacturer, manufacturer);
                Assert.AreEqual(engineOil.InStock, inStock);
                Assert.AreEqual(engineOil.PhotoPath, photoPath);
                mockDb.Verify(db => db.AddEngineOil(It.IsAny<EngineOil>()), Times.Once);
            }
        }


        [TestFixture]
        public class EngineOilServiceTests
        {
            [Test]
            public void ChangeEngineOilInfo_UpdatesEngineOilInfo()
            {
                // Arrange
                var mockDb = new Mock<IDBRequestSystem>();
                var engineOil = new EngineOil
                {
                    Composition = "synthetic",
                    Viscosity = "5W-30",
                    EngineType = EngineType.Gasoline_Engine,
                    Id = Guid.NewGuid(),
                    Name = "Engine oil",
                    Price = 50,
                    Manufacturer = "Manufacturer",
                    InStock = true,
                    PhotoPath = "photo.jpg"
                };
                mockDb.Setup(db => db.GetEngineOil(engineOil.Id)).Returns(engineOil);
                var service = new ProductCreator() { db = mockDb.Object };

                // Act
                var updatedEngineOil = service.ChangeEngineOilInfo(
                    composition: "mineral",
                    viscosity: "10W-40",
                    engineType: EngineType.Diesel_Engine,
                    id: engineOil.Id,
                    name: "Updated engine oil",
                    price: 60,
                    manufacturer: "New manufacturer",
                    inStock: false,
                    photoPath: "new-photo.jpg");

                // Assert
                Assert.IsNotNull(updatedEngineOil);
                Assert.AreEqual("mineral", updatedEngineOil.Composition);
                Assert.AreEqual("10W-40", updatedEngineOil.Viscosity);
                Assert.AreEqual(EngineType.Diesel_Engine, updatedEngineOil.EngineType);
                Assert.AreEqual(engineOil.Id, updatedEngineOil.Id);
                Assert.AreEqual("Updated engine oil", updatedEngineOil.Name);
                Assert.AreEqual(60, updatedEngineOil.Price);
                Assert.AreEqual("New manufacturer", updatedEngineOil.Manufacturer);
                Assert.IsFalse(updatedEngineOil.InStock);
                Assert.AreEqual("new-photo.jpg", updatedEngineOil.PhotoPath);
                mockDb.Verify(db => db.ChangeEngineOilInfo(engineOil.Id, updatedEngineOil), Times.Once);
            }
        }


        [TestFixture]
        public class TiresServiceTests
        {
            private Mock<IDBRequestSystem> mockDatabase;
            private ProductCreator tiresService;

            [SetUp]
            public void SetUp()
            {
                mockDatabase = new Mock<IDBRequestSystem>();
                tiresService = new ProductCreator() { db = mockDatabase.Object };
            }

            [Test]
            public void CreateTires_WithValidData_ShouldReturnNewTires()
            {
                // Arrange
                var season = SeasonType.Winter;
                var width = 195f;
                var profileHeight = 65f;
                var constructionType = ConstructionType.Tube_type;
                var rimDiameter = 15f;
                var loadIndex = 91f;
                var speedIndex = 'T';
                var name = "Example Tires";
                var price = 100m;
                var manufacturer = "Example Manufacturer";
                var inStock = true;
                var photoPath = "example.jpg";

                var expectedTires = new Tires
                {
                    Season = season,
                    Width = width,
                    ProfileHeight = profileHeight,
                    ConstructionType = constructionType,
                    RimDiameter = rimDiameter,
                    LoadIndex = loadIndex,
                    SpeedIndex = speedIndex,
                    Id = Guid.NewGuid(),
                    Name = name,
                    Price = price,
                    Manufacturer = manufacturer,
                    InStock = inStock,
                    PhotoPath = photoPath
                };

                mockDatabase.Setup(x => x.AddTires(expectedTires)).Verifiable();

                // Act
                var actualTires = tiresService.CreateTires(season, width, profileHeight, constructionType, rimDiameter,
                    loadIndex, speedIndex, name, price, manufacturer, inStock, photoPath);

                // Assert
                Assert.IsNotNull(actualTires);
                Assert.AreEqual(expectedTires.Season, actualTires.Season);
                Assert.AreEqual(expectedTires.Width, actualTires.Width);
                Assert.AreEqual(expectedTires.ProfileHeight, actualTires.ProfileHeight);
                Assert.AreEqual(expectedTires.ConstructionType, actualTires.ConstructionType);
                Assert.AreEqual(expectedTires.RimDiameter, actualTires.RimDiameter);
                Assert.AreEqual(expectedTires.LoadIndex, actualTires.LoadIndex);
                Assert.AreEqual(expectedTires.SpeedIndex, actualTires.SpeedIndex);
                Assert.AreEqual(expectedTires.Name, actualTires.Name);
                Assert.AreEqual(expectedTires.Price, actualTires.Price);
                Assert.AreEqual(expectedTires.Manufacturer, actualTires.Manufacturer);
                Assert.AreEqual(expectedTires.InStock, actualTires.InStock);
                Assert.AreEqual(expectedTires.PhotoPath, actualTires.PhotoPath);

                mockDatabase.Verify(db => db.AddTires(It.IsAny<Tires>()), Times.Once);
            }
        }


        [TestFixture]
        public class TiresTests
        {
            [Test]
            public void ChangeTiresInfo_UpdatesTiresInfoInDatabase()
            {
                // arrange
                Guid id = Guid.NewGuid();
                var mockDb = new Mock<IDBRequestSystem>();
                var tires = new Tires
                {
                    Season = SeasonType.Winter,
                    Width = 205,
                    ProfileHeight = 55,
                    ConstructionType = ConstructionType.Bias,
                    RimDiameter = 16,
                    LoadIndex = 91,
                    SpeedIndex = 'V',
                    Id = id,
                    Name = "Winter Tires",
                    Price = 100,
                    Manufacturer = "Tire Manufacturer",
                    InStock = true,
                    PhotoPath = "/path/to/photo"
                };
                mockDb.Setup(db => db.GetTires(id)).Returns(tires);
                var tiresService = new ProductCreator() { db = mockDb.Object };

                // act
                Tires? result = tiresService.ChangeTiresInfo(
                    SeasonType.Autumn,
                    215,
                    60,
                    ConstructionType.All_Season,
                    17,
                    94,
                    'W',
                    id,
                    "All-Season Tires",
                    120,
                    "New Tire Manufacturer",
                    false,
                    "/path/to/new/photo"
                );

                // assert
                Assert.IsNotNull(result);
                Assert.AreEqual(SeasonType.Autumn, result.Season);
                Assert.AreEqual(215, result.Width);
                Assert.AreEqual(60, result.ProfileHeight);
                Assert.AreEqual(ConstructionType.All_Season, result.ConstructionType);
                Assert.AreEqual(17, result.RimDiameter);
                Assert.AreEqual(94, result.LoadIndex);
                Assert.AreEqual('W', result.SpeedIndex);
                Assert.AreEqual(id, result.Id);
                Assert.AreEqual("All-Season Tires", result.Name);
                Assert.AreEqual(120, result.Price);
                Assert.AreEqual("New Tire Manufacturer", result.Manufacturer);
                Assert.AreEqual(false, result.InStock);
                Assert.AreEqual("/path/to/new/photo", result.PhotoPath);

                mockDb.Verify(db => db.ChangeTiresInfo(id, It.IsAny<Tires>()), Times.Once());
            }
        }


        [TestFixture]
        public class ProductTests
        {
            [Test]
            public void Demonstration_CreatesProductsInDatabase()
            {
                // arrange
                var mockDb = new Mock<IDBRequestSystem>();
                var productService = new ProductCreator() { db = mockDb.Object };

                // act
                productService.Demonstration();

                // assert
                mockDb.Verify(db => db.AddProduct(It.IsAny<Product>()), Times.Exactly(3));
            }
        }

    }
}

