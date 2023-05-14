using BusinessLogic.Application;
using BusinessLogic.Entities;
using BusinessLogic.Entities.Products;
using BusinessLogic.Entities.Users;
using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controller
{
    public class Controller : IController
    {
        Model.IModel model;

        // этого здесь быть не должно
        // не удаляю, на случай если срочно нужно будет показать хоть что то
        //public void InputInvite()
        //{
        //    //Authorization part
        //    while (true)
        //    {
        //        Console.WriteLine("1 - Регистрация пользователя");
        //        Console.WriteLine("2 -  Авторизация пользователя");

        //        var command = Console.ReadLine();

        //        if (command == "1")
        //        {
        //            Console.WriteLine("введите логин");
        //            string login = Console.ReadLine();
        //            Console.WriteLine("введите пароль");
        //            string password = Console.ReadLine();
        //            Console.WriteLine("введите роль:" +
        //                "1 - покупатель\n" +
        //                "2 - продавец\n" +
        //                "3 - администратор\n");
        //            Roles role = (Roles)Convert.ToInt32(Console.ReadLine());
        //            Console.WriteLine("введите фио");
        //            string fullName = Console.ReadLine();

        //            model.Registrate(login, password, role, fullName);
        //            Console.WriteLine($"пользователь {login} добавлен успешно");
        //        }
        //        else if (command == "2")
        //        {
        //            Console.WriteLine("введите логин");
        //            string login = Console.ReadLine();
        //            Console.WriteLine("введите пароль");
        //            string password = Console.ReadLine();

        //            if (model.LogIn(login, password) != null)
        //            {
        //                Console.WriteLine("вход выполнен успешно");
        //                break;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Такого пользователя не существует");
        //                continue;
        //            }
        //        }
        //    }

        //    //command input part
        //    while (true)
        //    {
        //        Console.WriteLine(
        //            "\n\n\n1 - просмотр списка пользователей\n" +
        //            "2 - просмотр списка товаров\n" +
        //            "3 - просмотр списка заказаов\n" +
        //            "4 - создать заказ\n" +
        //            "5 - отменить заказ\n" +
        //            "6 - добавить пользователя\n" +
        //            "7 - удалить пользователя\n\n\n");

        //        string command = Console.ReadLine();

        //        switch (command)
        //        {
        //            case "1":
        //                if (model.currentUser is Admin)
        //                {
        //                    var users = model.GetAllUsers();
        //                    foreach (var user in users)
        //                        Console.WriteLine(
        //                            $"Имя пользователя - {user.Login}\n" +
        //                            $"Пароль - {user.Password}\n" +
        //                            $"роль - {user.Role.ToString()}\n" +
        //                            $"полное имя - {user.FullName}\n\n");
        //                }
        //                else
        //                    Console.WriteLine("Недостаточно прав");
        //                break;
        //            case "2":
        //                if (model.currentUser is Admin)
        //                {
        //                    var prdoucts = model.GetAllProducts();
        //                    foreach (var product in prdoucts)
        //                        Console.WriteLine(
        //                            $"Имя товара - {product.Name}\n" +
        //                            $"производитель - {product.Manufacturer}\n" +
        //                            $"цена - {product.Price} \n" +
        //                            $" в наличии - {product.InStock} \n\n");
        //                }
        //                else
        //                    Console.WriteLine("Недостаточно прав");
        //                break;
        //            case "3":
        //                model.GetAllOrders();
        //                break;
        //            case "4":
        //                break;
        //            case "5":
        //                break;
        //            case "6":
        //                if (model.currentUser is Admin)
        //                {
        //                    Console.WriteLine("введите логин");
        //                    string login = Console.ReadLine();
        //                    Console.WriteLine("введите пароль");
        //                    string password = Console.ReadLine();
        //                    Console.WriteLine("введите роль:" +
        //                        "1 - покупатель\n" +
        //                        "2 - продавец\n" +
        //                        "3 - администратор\n");
        //                    Roles role = (Roles)Convert.ToInt32(Console.ReadLine());
        //                    Console.WriteLine("введите фио");
        //                    string fullName = Console.ReadLine();

        //                    model.Registrate(login, password, role, fullName);
        //                }
        //                break;
        //            case "7":
        //                if (model.currentUser is Admin)
        //                {
        //                    Console.WriteLine("введите логин");
        //                    string login = Console.ReadLine();

        //                    if (model.DeletUser(login))
        //                        Console.WriteLine("Удаление прошло успешно");
        //                    else
        //                        Console.WriteLine("Такого пользователя не существует");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Недостаточно прав");
        //                }
        //                break;
        //        }
        //    }
        //}

        public Controller(IModel model) 
        {
            this.model = model;
        }

        public bool SignUp(string Login, string password, Roles role, string fullName)
        {
            return model.AddUser(Login, password, role, fullName) != null;
        }

        public IUser? SignIn(string login, string password)
        {
            return model.SignIn(login, password);
        }

        public Product? CreateProduct(string name, decimal price, string manufacturer, bool inStock)
        {
            return model.CreateProduct(name, price, manufacturer, inStock);
        }

        public Product? ChangeProductInfo(Guid id, string name, decimal price, string manufacturer, bool inStock)
        {
            return model.ChangeProductInfo(id, name, price, manufacturer, inStock);
        }

        public bool DeleteProduct(Guid id)
        {
            return model.DeleteProduct(id);
        }

        public List<Product> GetAllProducts()
        {
            return model.GetAllProducts();
        }

        public Product? GetProductById(Guid id)
        {
            return model.GetProductById(id);
        }

        public Order? CreateOrder(string byerFullName)
        {
            return model.CreateOrder(byerFullName);
        }

        public Order? CancelOrder(Guid id)
        {
            return model.CancelOrder(id);
        }

        public Order? GetOrderById(Guid id)
        {
            return model.GetOrderById(id);
        }

        public List<Order>? GetAllUserOrders(string logIn)
        {
            return model.GetAllUserOrders(logIn);
        }

        public IUser? CreateUser(string logIn, string password, Roles role, string fullName)
        {
            return model.CreateUser(logIn, password, role, fullName);
        }

        public IUser? ChangeUserInfo(string logIn, string newLogIn, string password, string fullName)
        {
            return model.ChangeUserInfo(logIn, newLogIn, password, fullName);
        }

        public bool DeleteUser(string logIn)
        {
            return model.DeleteUser(logIn);
        }

        public List<IUser>? GetAllUsers()
        {
           return model.GetAllUsers();
        }

        public IUser? GetCertainUser(string logIn)
        {
            return model.GetCertainUser(logIn);
        }

        public bool AddProductInBucket(Guid id, int count)
        {
            return model.AddProductInBucket(id, count);
        }

        public bool DeleteProductInBucket(Guid id)
        {
            return model.DeleteProductInBucket(id);
        }

        public void LogOut()
        {
            model.LogOut();
        }

        public IUser? SwitchUser(string Login, string password)
        {
            return model.SwitchUser(Login, password);
        }

        public Car CreateCar(CarModel model, EngineType engine, GearboxType gearbox, float fuelTankCapacity, DateTime manufactureDate, CarColor color, WheelDriveType wheelDrive, float power, float fuelConsumption, string name, decimal price, string manufacturer, bool inStock, string photoPath)
        {
            return this.model.CreateCar(model, engine, gearbox, fuelTankCapacity, manufactureDate, color, wheelDrive, power, fuelConsumption, name, price, manufacturer, inStock, photoPath);

        }

        public Car? ChangeCarInfo(CarModel? model, EngineType? engine, GearboxType? gearbox, float? fuelTankCapacity, DateTime? manufactureDate, CarColor? color, WheelDriveType? wheelDrive, float? power, float? fuelConsumption, Guid id, string? name, decimal? price, string? manufacturer, bool? inStock, string? photoPath)
        {
            return this.model.ChangeCarInfo(model, engine, gearbox, fuelTankCapacity, manufactureDate, color, wheelDrive, power, fuelConsumption, id, name, price, manufacturer, inStock, photoPath);
        }

        public EngineOil CreateEngineOil(string composition, string viscosity, EngineType engineType, string name, decimal price, string manufacturer, bool inStock, string photoPath)
        {
            return this.model.CreateEngineOil(composition, viscosity, engineType, name, price, manufacturer, inStock, photoPath);
        }

        public EngineOil? ChangeEngineOilInfo(string? composition, string? viscosity, EngineType? engineType, Guid id, string? name, decimal? price, string? manufacturer, bool? inStock, string? photoPath)
        {
            return this.model.ChangeEngineOilInfo(composition, viscosity, engineType, id, name, price, manufacturer, inStock, photoPath);
        }

        public Tires CreateTires(SeasonType season, float width, float profileHeight, ConstructionType constructionType, float rimDiameter, float loadIndex, char speedIndex, string name, decimal price, string manufacturer, bool inStock, string photoPath)
        {
            return this.model.CreateTires(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, name, price, manufacturer, inStock, photoPath);
        }

        public Tires? ChangeTiresInfo(SeasonType? season, float? width, float? profileHeight, ConstructionType? constructionType, float? rimDiameter, float? loadIndex, char? speedIndex, Guid id, string? name, decimal? price, string? manufacturer, bool? inStock, string? photoPath)
        {
            return this.model.ChangeTiresInfo(season, width, profileHeight, constructionType, rimDiameter, loadIndex, speedIndex, id, name, price, manufacturer, inStock, photoPath);
        }

        public IUser? AddUser(string Login, string password, Roles role, string fullName)
        {
            return model.AddUser(Login, password, role, fullName);
        }

        public List<Order>? GetAllOrders()
        {
            return model.GetAllOrders();
        }
    }
}
