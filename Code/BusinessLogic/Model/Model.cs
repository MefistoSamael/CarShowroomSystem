using BusinessLogic.Application;
using BusinessLogic.Entities;
using BusinessLogic.Entities.Products;
using BusinessLogic.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BusinessLogic.Model
{
    public class Model : IModel
    {
    
        private UserControlSystem userControlSystem;
        private CustomerRequestHandler customerRequestHandler;
        private OrderHandleSystem orderHandleSystem;
        private ProductCreator productCreator;
        private IDBRequestSystem dBRequestSystem;

        public IUser? currentUser;
        public Model()
        {
            dBRequestSystem = new TopDB();
            userControlSystem = new UserControlSystem();
            customerRequestHandler = new CustomerRequestHandler();
            orderHandleSystem = new OrderHandleSystem();
            productCreator = new ProductCreator();

            // установка всех зависимостей

            //userControlSystem
            userControlSystem.customerRequestHandler = customerRequestHandler;
            userControlSystem.orderHandleSystem = orderHandleSystem;
            userControlSystem.DB = dBRequestSystem;

            //CustomerRequestHandler
            customerRequestHandler.userControlSystem = userControlSystem;

            //OrderHandleSystem
            orderHandleSystem.DB = dBRequestSystem;

            //ProductCreator
            productCreator.db = dBRequestSystem;

            productCreator.Demonstration();
            Demonstration();
        }

        public void LogOut()
        {
            userControlSystem.LogOut();
            currentUser = null;
        }

        public IUser? SwitchUser(string Login, string password)
        {
            userControlSystem.SwitchUser(Login, password);
            return currentUser = customerRequestHandler.CurrentUser;
        }

        public bool DeletUser(string login)
        {
            return customerRequestHandler.DeleteUser(login);
        }

        public List<Product>? GetAllProducts()
        {
            return dBRequestSystem.GetAllProducts();
        }

        public List<IUser>? GetAllUsers()
        {
            return dBRequestSystem.GetAllUsers();
        }

        public List<Order>? GetAllOrders()
        {
            return dBRequestSystem.GetAllOrders();
        }

        public void Demonstration()
        {
            AddUser("c", "1", Roles.customer, "Ivan  Lupko");
            AddUser("s", "1", Roles.seller, "Anotonio Pruchi");
            AddUser("a", "1", Roles.admin, "Daniil Gryaznii");
        }

        public IUser? AddUser(string logIn, string password, Roles role, string fullName)
        {
            return userControlSystem.CreateUser(logIn, password, role, fullName);
        }

        public IUser? SignIn(string logIn, string password)
        {
            userControlSystem.LogIn(logIn, password);
            return currentUser = customerRequestHandler.CurrentUser;
        }

        // создает товар и заносит его в базу данных

        public Product CreateProduct(string name, decimal price, string manufacturer, bool inStock)
        {
            // создание пользователя доступно в двух случаях:
            // 1) админ создает пользователя
            // 2) пользователь создается заранее для демонстрации работы программы
            if (currentUser == null || currentUser is Admin)
                return productCreator.CreateProduct(new Guid(), name, manufacturer, inStock, price);
            else
                throw new Exception("Invalid product creation");
        }

        public Product ChangeProductInfo(Guid id, string name, decimal price, string manufacturer, bool inStock)
        {
            throw new Exception("will be added sooner");
        }

        public bool DeleteProduct(Guid id)
        {
            throw new Exception("will be added sooner");
        }

        //
        public Car CreateCar(CarModel model, EngineType engine, GearboxType gearbox, float fuelTankCapacity, DateTime manufactureDate, CarColor color, WheelDriveType wheelDrive, float power, float fuelConsumption, string name, decimal price, string manufacturer, bool inStock, string photoPath)
        {
            return productCreator.CreateCar(model, engine, gearbox, fuelTankCapacity, manufactureDate, color, wheelDrive, power, fuelConsumption, name, price, manufacturer, inStock, photoPath);

        }

        public Car? ChangeCarInfo(CarModel? model, EngineType? engine, GearboxType? gearbox, float? fuelTankCapacity, DateTime? manufactureDate, CarColor? color, WheelDriveType? wheelDrive, float? power, float? fuelConsumption, Guid id, string? name, decimal? price, string? manufacturer, bool? inStock, string? photoPath)
        {
            return productCreator.ChangeCarInfo(model, engine, gearbox, fuelTankCapacity, manufactureDate, color, wheelDrive, power, fuelConsumption, id, name, price, manufacturer, inStock, photoPath);
        }

        public EngineOil CreateEngineOil(string composition, string viscosity, EngineType engineType, string name, decimal price, string manufacturer, bool inStock, string photoPath)
        {
            return productCreator.CreateEngineOil(composition, viscosity, engineType, name, price, manufacturer, inStock, photoPath);
        }

        public EngineOil? ChangeEngineOilInfo(string? composition, string? viscosity, EngineType? engineType, Guid id, string? name, decimal? price, string? manufacturer, bool? inStock, string? photoPath)
        {
            return productCreator.ChangeEngineOilInfo(composition, viscosity, engineType, id, name, price, manufacturer, inStock, photoPath);
        }

        public Tires CreateTires(SeasonType season, float width, float profileHeight, ConstructionType constructionType, float rimDiameter, float loadIndex, char speedIndex, string name, decimal price, string manufacturer, bool inStock, string photoPath)
        {
            return productCreator.CreateTires(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, name, price, manufacturer, inStock, photoPath);
        }

        public Tires? ChangeTiresInfo(SeasonType? season, float? width, float? profileHeight, ConstructionType? constructionType, float? rimDiameter, float? loadIndex, char? speedIndex, Guid id, string? name, decimal? price, string? manufacturer, bool? inStock, string? photoPath)
        {
            return productCreator.ChangeTiresInfo(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, id, name, price, manufacturer, inStock, photoPath);
        }


        public Product? GetProductById(Guid id)
        {
            return dBRequestSystem.GetProductByGuid(id);
        }

        public Order? CreateOrder(string byerFullName)
        {
            currentUserCheck();

            if (currentUser!.Bucket.Count == 0)
                return null;

            var order = orderHandleSystem.CreateOrder(currentUser!.Login, byerFullName, currentUser.Bucket);

            // корзина должна чиститься после совершения заказа
            currentUser.Bucket = new Dictionary<Guid, int>();

            return order;
        }

        public Order? CancelOrder(Guid id)
        {
            currentUserCheck();

            // получаем заказа, чтобы сделать проверку на допустимость отмены заказа
            // по задумке заказа может отменить только пользователь его создавший или адиминистратор
            Order? order = dBRequestSystem.GetOrder(id);

            if (order == null)
                return null;

            // если отмена происходит пользователем не сделавшим заказ и он не админ
            // то где то произошла ошибка
            if (correctUserCheck(order.CreatorUserName))
                return orderHandleSystem.ReturnOrder(id);
            else
                return null;

            
        }

        public Order? GetOrderById(Guid id)
        {
            currentUserCheck();

            Order? order = dBRequestSystem.GetOrder(id);

            if (order == null)
                return null;

            // если пользователь пытается получить не свой заказ - это ошибка в вышестоящем модуле(представление или контроллер)
            // поскольку покупатель и продавец - должны знать только о своих заказах
            if (correctUserCheck(order.CreatorUserName))
                return dBRequestSystem.GetOrder(id);
            else
                return null;

        }

        public List<Order> GetAllUserOrders(string logIn)
        {
            currentUserCheck();

            // если пользователь пытается получить не свой заказ - это ошибка в вышестоящем модуле(представление или контроллер)
            // поскольку покупатель и продавец - должны знать только о своих заказах
            if (correctUserCheck(logIn))
                //при помощи linQ запроса получаем заказы где userName(login) создателя равен интересующему на логину
                return dBRequestSystem.GetAllOrders().Where((Order order) => order.CreatorUserName == logIn).ToList();
            else throw new Exception("Order acces from wrong user (not admin or not creator of order)");
        }

        public IUser? CreateUser(string logIn, string password, Roles role, string fullName)
        {
            // создание пользователя доступно в двух случаях:
            // 1) админ создает пользователя
            // 2) пользователь создается заранее для демонстрации работы программы
            if (currentUser == null || currentUser is Admin)
                return userControlSystem.CreateUser(logIn, password, role, fullName);
            else
                throw new Exception("Invalid user creation attempt");
        }

        public IUser? ChangeUserInfo(string logIn, string newLogIn, string password, string fullName)
        {
            if (currentUser is Admin)
                return userControlSystem.ChangeUserInfo(logIn, newLogIn, password, fullName);
            else 
                throw new Exception("Invalid user change attempt");
        }

        public bool DeleteUser(string logIn)
        {
            if (currentUser is Admin)
                return userControlSystem.DeleteUser(logIn);
            else
                throw new Exception("Invalid user delete attempt");
        }

        public IUser? GetCertainUser(string logIn)
        {
            if (currentUser is Admin)
                return dBRequestSystem.GetCertainUser(logIn);
            else 
                throw new Exception("Invalid user get attempt");
        }

        public bool AddProductInBucket(Guid id, int count)
        {
            currentUserCheck();

            if (dBRequestSystem.ContainsProductById(id))
            {
                currentUser!.AddProductInBucket(id, count);
                return true;
            }
            else return false;
        }

        public bool DeleteProductInBucket(Guid id)
        {
            currentUserCheck();
            
            if(currentUser!.Bucket.ContainsKey(id))
            {
                currentUser!.DeleteProductInBucket(id);
                return true;
            }
            else return false;
        }

        private void currentUserCheck()
        {
            if (currentUser == null)
                throw new Exception("Error: user isnt loginned");
        }

        // проверяет явялется ли переданный пользователь корректным (для случая работы с заказом)
        private bool correctUserCheck(string creatorUserName) => currentUser is Admin || currentUser!.Login == creatorUserName;
    }
}
