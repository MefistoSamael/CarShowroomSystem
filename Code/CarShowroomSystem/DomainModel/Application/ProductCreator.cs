using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CarShowroomSystem.Entities.Products;

namespace CarShowroomSystem.Application
{
    internal class ProductCreator
    {
        public IDBRequestSystem db { get; set; }
        public Product CreateProduct(Guid id, string name, string Manufacturer, bool InStock, decimal Price)
        {
            Product product = new Product
            {
                Id = id,
                Name = name,
                Price = Price,
                Manufacturer = Manufacturer,
                InStock = InStock
            };

            db.AddProduct(product);

            return product;
        }

        public Car CreateCar(CarModel model, EngineType engine, GearboxType gearbox, float fuelTankCapacity, DateTime manufactureDate, CarColor color, WheelDriveType wheelDrive, float power, float fuelConsumption, string name, decimal price, string manufacturer, bool inStock, string photoPath)
        {
            Car car = new Car
            {
                Id = Guid.NewGuid(),
                Model = model,
                Engine = engine,
                Gearbox = gearbox,
                FuelTankCapacity = fuelTankCapacity,
                ManufactureDate = manufactureDate,
                Color = color,
                WheelDrive = wheelDrive,
                Power = power,
                FuelConsumption = fuelConsumption,
                Name = name,
                Price = price,
                Manufacturer = manufacturer,
                InStock = inStock,
                PhotoPath = photoPath
            };

            db.AddCar(car);

            return car;

        }

        public Car? ChangeCarInfo(CarModel? model, EngineType? engine, GearboxType? gearbox, float? fuelTankCapacity, DateTime? manufactureDate, CarColor? color, WheelDriveType? wheelDrive, float? power, float? fuelConsumption, Guid id, string? name, decimal? price, string? manufacturer, bool? inStock, string? photoPath)
        {
            Car? car = db.GetCar(id);

            if (car == null) 
                return null;

            // производим проверку аргументов на null и если они не равны Null, то присваиваем 
            if (model.HasValue) // Проверяем, было ли передано значение для модели
                car.Model = model.Value; // Присваиваем значение из аргумента метода

            if (engine.HasValue)
                car.Engine = engine.Value;

            if (gearbox.HasValue)
                car.Gearbox = gearbox.Value;

            if (fuelTankCapacity.HasValue)
                car.FuelTankCapacity = fuelTankCapacity.Value;

            if (manufactureDate.HasValue)
                car.ManufactureDate = manufactureDate.Value;

            if (color.HasValue)
                car.Color = color.Value;

            if (wheelDrive.HasValue)
                car.WheelDrive = wheelDrive.Value;

            if (power.HasValue)
                car.Power = power.Value;

            if (fuelConsumption.HasValue)
                car.FuelConsumption = fuelConsumption.Value;

            if (name != null)
                car.Name = name;

            if (price.HasValue)
                car.Price = price.Value;

            if (manufacturer != null)
                car.Manufacturer = manufacturer;

            if (inStock.HasValue)
                car.InStock = inStock.Value;

            if (photoPath != null)
                car.PhotoPath = photoPath;

            db.ChangeCarInfo(id, car);

            return car;
        }

        public EngineOil CreateEngineOil(string composition, string viscosity, EngineType engineType, string name, decimal price, string manufacturer, bool inStock, string photoPath)
        {
            EngineOil engineOil = new EngineOil { 
                Composition = composition,
                Viscosity = viscosity,
                EngineType = engineType,
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                Manufacturer = manufacturer,
                InStock = inStock,
                PhotoPath = photoPath
            };

            db.AddEngineOil(engineOil);

            return engineOil;
        }

        public EngineOil? ChangeEngineOilInfo(string? composition, string? viscosity, EngineType? engineType, Guid id, string? name, decimal? price, string? manufacturer, bool? inStock, string? photoPath)
        {
            EngineOil? engineOil = db.GetEngineOil(id);

            if (engineOil is null)
                return null;

            // производим проверку аргументов на null и если они не равны Null, то меняем их
            if (composition != null)
                engineOil.Composition = composition;

            if (viscosity != null)
                engineOil.Viscosity = viscosity;

            if (engineType.HasValue)
                engineOil.EngineType = engineType.Value;

            engineOil.Id = id;

            if (name != null)
                engineOil.Name = name;

            if (price.HasValue)
                engineOil.Price = price.Value;

            if (manufacturer != null)
                engineOil.Manufacturer = manufacturer;

            if (inStock.HasValue)
                engineOil.InStock = inStock.Value;

            if (photoPath != null)
                engineOil.PhotoPath = photoPath;

            db.ChangeEngineOilInfo(id, engineOil);

            return engineOil;
        }

        public Tires CreateTires(SeasonType season, float Width, float ProfileHeight, ConstructionType ConstructionType, float RimDiameter, float LoadIndex, char SpeedIndex, string name, decimal price, string manufacturer, bool inStock, string photoPath)
        {
            Tires tires = new Tires
            {
                Season = season,
                Width = Width,
                ProfileHeight = ProfileHeight,
                ConstructionType = ConstructionType,
                RimDiameter = RimDiameter,
                LoadIndex = LoadIndex,
                SpeedIndex = SpeedIndex,
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                Manufacturer = manufacturer,
                InStock = inStock,
                PhotoPath = photoPath
            };

            db.AddTires(tires);

            return tires;
        }

        public Tires? ChangeTiresInfo(SeasonType? season, float? width, float? profileHeight, ConstructionType? constructionType, float? rimDiameter, float? loadIndex, char? speedIndex, Guid id, string? name, decimal? price, string? manufacturer, bool? inStock, string? photoPath)
        {
            Tires? tires = db.GetTires(id);

            if (tires is null)
                return null;

            if (tires is null)
                return null;

            if (season.HasValue)
                tires.Season = season.Value;

            if (width.HasValue)
                tires.Width = width.Value;

            if (profileHeight.HasValue)
                tires.ProfileHeight = profileHeight.Value;

            if (constructionType.HasValue)
                tires.ConstructionType = constructionType.Value;

            if (rimDiameter.HasValue)
                tires.RimDiameter = rimDiameter.Value;

            if (loadIndex.HasValue)
                tires.LoadIndex = loadIndex.Value;

            if (speedIndex.HasValue)
                tires.SpeedIndex = speedIndex.Value;

            if (name != null)
                tires.Name = name;

            if (price.HasValue)
                tires.Price = price.Value;

            if (manufacturer != null)
                tires.Manufacturer = manufacturer;

            if (inStock.HasValue)
                tires.InStock = inStock.Value;

            if (photoPath != null)
                tires.PhotoPath = photoPath;

            db.ChangeTiresInfo(id, tires);

            return tires;
        }

        public void Demonstration()
        {
            CreateProduct(Guid.NewGuid(), "Product 1", "IP ISHO", true, 25);
            CreateProduct(Guid.NewGuid(), "Product 2", "ROGA I KOPITA", false, 31);
            CreateProduct(Guid.NewGuid(), "Product 3", "Antonio Pripizduchi", true, 5);
        }
    }
}
