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

        public Car CreateCar(string model, EngineType engine, GearboxType gearbox, float fuelTankCapacity, DateTime manufactureDate, string color, WheelDriveType wheelDrive, float power, float fuelConsumption, string name, decimal price, string manufacturer, bool inStock, string photoPath)
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

        public Car? ChangeCarInfo(string? model, EngineType? engine, GearboxType? gearbox, float? fuelTankCapacity, DateTime? manufactureDate, string? color, WheelDriveType? wheelDrive, float? power, float? fuelConsumption, Guid id, string? name, decimal? price, string? manufacturer, bool? inStock, string? photoPath)
        {
            Car? car = db.GetCar(id);

            if (car == null) 
                return null;

            // производим проверку аргументов на null и если они не равны Null, то присваиваем 
            if (model != null) // Проверяем, было ли передано значение для модели
                car.Model = model; // Присваиваем значение из аргумента метода

            if (engine.HasValue)
                car.Engine = engine.Value;

            if (gearbox.HasValue)
                car.Gearbox = gearbox.Value;

            if (fuelTankCapacity.HasValue)
                car.FuelTankCapacity = fuelTankCapacity.Value;

            if (manufactureDate.HasValue)
                car.ManufactureDate = manufactureDate.Value;

            if (color != null)
                car.Color = color;

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
            EngineType engineType = EngineType.Gasoline_Engine;
            GearboxType gearboxType = GearboxType.Automatic_Transmission;
            float fuelTankCapacity = 50.5f;
            DateTime manufactureDate = new DateTime(2022, 3, 15);
            WheelDriveType wheelDriveType = WheelDriveType.Front_Wheel_Drive;
            float power = 150.0f;
            float fuelConsumption = 8.5f;
            string name = "My Car";
            decimal price = 25000.0m;
            string manufacturer = "Toyota";
            bool inStock = true;
            string photoPath = "https://freepngimg.com/download/temp_png/9-2-car-high-quality-png.jpeg";

            CreateCar("Toyota_Corolla", engineType, gearboxType, fuelTankCapacity, manufactureDate, "Blue", wheelDriveType, power, fuelConsumption, name, price, manufacturer, inStock, photoPath);

            string composition = "Synthetic";
            string viscosity = "5W-30";
            EngineType engineType1 = EngineType.Gasoline_Engine;
            string name1 = "Premium Engine Oil";
            decimal price1 = 49.99m;
            string manufacturer1 = "OilCo";
            bool inStock1 = true;
            string photoPath1 = "https://cdn21vek.by/img/galleries/7645/821/preview_b/edgeprofessionallonglifeiii5w30157eco_castrol_62eb8a685bae8.jpeg";

            CreateEngineOil(composition, viscosity, engineType1, name1, price1, manufacturer1, inStock1, photoPath1);

            SeasonType season = SeasonType.Summer;
            float width = 205.0f;
            float profileHeight = 55.0f;
            ConstructionType constructionType = ConstructionType.Tubeless;
            float rimDiameter = 16.0f;
            float loadIndex = 91.0f;
            char speedIndex = 'H';
            string name3 = "TireName2";
            decimal price3 = 149.99m;
            string manufacturer3= "TireCo";
            bool inStock3 = true;
            string photoPath3 = "https://cdn21vek.by/img/galleries/343/540/preview_b/artmotion27418570r1488t_belshina_56cad0d10f167.jpeg";

            CreateTires(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, name3, price3, manufacturer3, inStock3, photoPath3);
            CreateTires(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, name3, price3, manufacturer3, inStock3, photoPath3);
            CreateTires(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, name3, price3, manufacturer3, inStock3, photoPath3);
            CreateTires(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, name3, price3, manufacturer3, inStock3, photoPath3);
            CreateTires(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, name3, price3, manufacturer3, inStock3, photoPath3);
            CreateTires(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, name3, price3, manufacturer3, inStock3, photoPath3);
            CreateTires(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, name3, price3, manufacturer3, inStock3, photoPath3);
            CreateTires(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, name3, price3, manufacturer3, inStock3, photoPath3);


        }
    }
}
