using BusinessLogic.Entities;
using BusinessLogic.Entities.Products;
using BusinessLogic.Entities.Users;
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
        Model.Model model;

        // этого здесь быть не должно
        // не удаляю, на случай если срочно нужно будет показать хоть что то
        public void InputInvite()
        {
            //Authorization part
            while (true)
            {
                Console.WriteLine("1 - Регистрация пользователя");
                Console.WriteLine("2 -  Авторизация пользователя");

                var command = Console.ReadLine();

                if (command == "1")
                {
                    Console.WriteLine("введите логин");
                    string login = Console.ReadLine();
                    Console.WriteLine("введите пароль");
                    string password = Console.ReadLine();
                    Console.WriteLine("введите роль:" +
                        "1 - покупатель\n" +
                        "2 - продавец\n" +
                        "3 - администратор\n");
                    Roles role = (Roles)Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("введите фио");
                    string fullName = Console.ReadLine();

                    model.Registrate(login, password, role, fullName);
                    Console.WriteLine($"пользователь {login} добавлен успешно");
                }
                else if (command == "2")
                {
                    Console.WriteLine("введите логин");
                    string login = Console.ReadLine();
                    Console.WriteLine("введите пароль");
                    string password = Console.ReadLine();

                    if (model.LogIn(login, password) != null)
                    {
                        Console.WriteLine("вход выполнен успешно");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Такого пользователя не существует");
                        continue;
                    }
                }
            }

            //command input part
            while (true)
            {
                Console.WriteLine(
                    "\n\n\n1 - просмотр списка пользователей\n" +
                    "2 - просмотр списка товаров\n" +
                    "3 - просмотр списка заказаов\n" +
                    "4 - создать заказ\n" +
                    "5 - отменить заказ\n" +
                    "6 - добавить пользователя\n" +
                    "7 - удалить пользователя\n\n\n");

                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        if (model.currentUser is Admin)
                        {
                            var users = model.GetAllUsers();
                            foreach (var user in users)
                                Console.WriteLine(
                                    $"Имя пользователя - {user.Login}\n" +
                                    $"Пароль - {user.Password}\n" +
                                    $"роль - {user.Role.ToString()}\n" +
                                    $"полное имя - {user.FullName}\n\n");
                        }
                        else
                            Console.WriteLine("Недостаточно прав");
                        break;
                    case "2":
                        if (model.currentUser is Admin)
                        {
                            var prdoucts = model.GetAllProducts();
                            foreach (var product in prdoucts)
                                Console.WriteLine(
                                    $"Имя товара - {product.Name}\n" +
                                    $"производитель - {product.Manufacturer}\n" +
                                    $"цена - {product.Price} \n" +
                                    $" в наличии - {product.InStock} \n\n");
                        }
                        else
                            Console.WriteLine("Недостаточно прав");
                        break;
                    case "3":
                        model.GetAllOrders();
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        if (model.currentUser is Admin)
                        {
                            Console.WriteLine("введите логин");
                            string login = Console.ReadLine();
                            Console.WriteLine("введите пароль");
                            string password = Console.ReadLine();
                            Console.WriteLine("введите роль:" +
                                "1 - покупатель\n" +
                                "2 - продавец\n" +
                                "3 - администратор\n");
                            Roles role = (Roles)Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("введите фио");
                            string fullName = Console.ReadLine();

                            model.Registrate(login, password, role, fullName);
                        }
                        break;
                    case "7":
                        if (model.currentUser is Admin)
                        {
                            Console.WriteLine("введите логин");
                            string login = Console.ReadLine();

                            if (model.DeletUser(login))
                                Console.WriteLine("Удаление прошло успешно");
                            else
                                Console.WriteLine("Такого пользователя не существует");
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно прав");
                        }
                        break;
                }
            }
        }

        public bool SignUp(string Login, string password, Roles role, string fullName)
        {
            return model.Registrate(Login, password, role, fullName);
        }

        public IUser? SignIn(string login, string password)
        {
            return model.LogIn(login, password);
        }

        public Product CreateProduct(string name, decimal price, string manufacturer, bool inStock)
        {
            throw new NotImplementedException();
        }

        public Product ChangeProductInfo(Guid id, string name, decimal price, string manufacturer, bool inStock)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Order CreateOrder(string byerFullName)
        {
            throw new NotImplementedException();
        }

        public Order CancelOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllUserOrders(string logIn)
        {
            throw new NotImplementedException();
        }

        public IUser CreateUser(string logIn, string password, Roles role, string fullName)
        {
            throw new NotImplementedException();
        }

        public IUser ChangeUserInfo(string logIn, string newLogIn, string password, Roles role, string fullName)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(string logIn)
        {
            throw new NotImplementedException();
        }

        public List<IUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public IUser GetCertainUser(string logIn)
        {
            throw new NotImplementedException();
        }

        public bool AddProductInBucket(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductInBucket(Guid id)
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }

        public IUser? SwitchUser(string Login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
