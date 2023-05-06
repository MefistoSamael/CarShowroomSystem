using BusinessLogic.Entities.Products;
using BusinessLogic.Entities.Users;
using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public interface IModel
    {
        public bool SignUp(string Login, string password, Roles role, string fullName);

        public IUser? SignIn(string login, string password);

        public void LogOut();

        public IUser? SwitchUser(string Login, string password);



        public Product? CreateProduct(string name, decimal price, string manufacturer, bool inStock);

        //если какое то поле не изменяется - передавать Null
        public Product? ChangeProductInfo(Guid id, string name, decimal price, string manufacturer, bool inStock);

        public Car? CreateCar(CarModel model, EngineType engine, GearboxType gearbox, float fuelTankCapacity, DateTime manufactureDate, CarColor color, WheelDriveType wheelDrive, float power, float fuelConsumption, string name, decimal price, string manufacturer, bool inStock);

        public Car? ChangeCarInfo(CarModel model, EngineType engine, GearboxType gearbox, float fuelTankCapacity, DateTime manufactureDate, CarColor color, WheelDriveType wheelDrive, float power, float fuelConsumption, Guid id, string name, decimal price, string manufacturer, bool inStock);
        
        public EngineOil? CreateEngineOil(string composition, string viscosity, EngineType engineType, Guid id, string name, decimal price, string manufacturer, bool inStock);

        public EngineOil? ChangeEngineOilInfo(string composition, string viscosity, EngineType engineType, Guid id, string name, decimal price, string manufacturer, bool inStock);

        public Tires? CreateTires(SeasonType Season, float Width, float ProfileHeight, ConstructionType ConstructionType, float RimDiameter, float LoadIndex, char SpeedIndex, Guid id, string name, decimal price, string manufacturer, bool inStock);

        public Tires? ChangeTiresInfo(SeasonType Season, float Width, float ProfileHeight, ConstructionType ConstructionType, float RimDiameter, float LoadIndex, char SpeedIndex, Guid id, string name, decimal price, string manufacturer, bool inStock);


        public bool DeleteProduct(Guid id);

        public List<Product> GetAllProducts();

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
    }
}
