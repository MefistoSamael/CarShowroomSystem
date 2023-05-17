using CarShowroomSystem.Entities.Products;
using CarShowroomSystem.Entities.Users;
using CarShowroomSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomSystem.Model
{
    public interface IModel
    {
        public IUser? AddUser(string Login, string password, Roles role, string fullName);

        public IUser? SignIn(string login, string password);

        public void LogOut();

        public IUser? SwitchUser(string Login, string password);



        public Product? CreateProduct(string name, decimal price, string manufacturer, bool inStock);

        //если какое то поле не изменяется - передавать Null
        public Product? ChangeProductInfo(Guid id, string name, decimal price, string manufacturer, bool inStock);

        public Car CreateCar(CarModel model, EngineType engine, GearboxType gearbox, float fuelTankCapacity, DateTime manufactureDate, CarColor color, WheelDriveType wheelDrive, float power, float fuelConsumption, string name, decimal price, string manufacturer, bool inStock, string photoPath);

        public Car? ChangeCarInfo(CarModel? model, EngineType? engine, GearboxType? gearbox, float? fuelTankCapacity, DateTime? manufactureDate, CarColor? color, WheelDriveType? wheelDrive, float? power, float? fuelConsumption, Guid id, string? name, decimal? price, string? manufacturer, bool? inStock, string? photoPath);

        public EngineOil CreateEngineOil(string composition, string viscosity, EngineType engineType, string name, decimal price, string manufacturer, bool inStock, string photoPath);

        public EngineOil? ChangeEngineOilInfo(string? composition, string? viscosity, EngineType? engineType, Guid id, string? name, decimal? price, string? manufacturer, bool? inStock, string? photoPath);

        public Tires CreateTires(SeasonType season, float Width, float ProfileHeight, ConstructionType ConstructionType, float RimDiameter, float LoadIndex, char SpeedIndex, string name, decimal price, string manufacturer, bool inStock, string photoPath);

        public Tires? ChangeTiresInfo(SeasonType? season, float? width, float? profileHeight, ConstructionType? constructionType, float? rimDiameter, float? loadIndex, char? speedIndex, Guid id, string? name, decimal? price, string? manufacturer, bool? inStock, string? photoPath);

        public bool DeleteProduct(Guid id);

        public List<Product>? GetAllProducts();

        public Product? GetProductById(Guid id);



        public Order? CreateOrder(string byerFullName);

        public Order? CancelOrder(Guid id);

        public Order? GetOrderById(Guid id);

        public List<Order>? GetAllUserOrders(string logIn);



        public IUser? CreateUser(string logIn, string password, Roles role, string fullName);

        public IUser? ChangeUserInfo(string logIn, string newLogIn, string password, string fullName);

        public bool DeleteUser(string logIn);

        public List<IUser>? GetAllUsers();

        public IUser? GetCertainUser(string logIn);



        public bool AddProductInBucket(Guid id, int count);

        public bool DeleteProductInBucket(Guid id);

        public List<Order>? GetAllOrders();
    }
}
