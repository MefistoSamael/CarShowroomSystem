using BusinessLogic.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Controller
    {
        Model model;
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
                }
                else if (command == "2")
                {
                    Console.WriteLine("введите логин");
                    string login = Console.ReadLine();
                    Console.WriteLine("введите пароль");
                    string password = Console.ReadLine();

                    if (model.LogIn(login, password)) 
                        break;
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
    
        public Controller(Model model) 
        {
            this.model = model;
        }
    }
}
