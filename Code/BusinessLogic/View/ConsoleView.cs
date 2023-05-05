using BusinessLogic.Entities.Products;
using BusinessLogic.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.View
{
    public class ConsoleView
    {
        Controller.IController controller;
        IUser? User { get; set; }
        List<CustomerSellerCommands> commands;
        List<AdminCommand> adminCommands;
        public ConsoleView(Controller.IController controller) 
        {
            this.controller = controller;

            commands = new List<CustomerSellerCommands>();
            for (int i = 1; i < (int)CustomerSellerCommands.Costil1; i++)
            {
                commands.Add((CustomerSellerCommands)i);
            }

            adminCommands = new List<AdminCommand>();
            for (int i = (int)CustomerSellerCommands.Costil1 + 1; i < (int)AdminCommand.Costil2; i++)
            {
                adminCommands.Add((AdminCommand)i);
            }

        }

        public void Main()
        {
            AuthorizationPart();

            InterractionPart();
        }
        private void AuthorizationPart()
        {
            Console.WriteLine("Hi");
            while (true) 
            {
                // без приведения к int выведет SignIn
                Console.WriteLine($"\n{(int)RegistrationCommands.SignIn} - {RegistrationCommands.SignIn.ToString()}\n{(int)RegistrationCommands.SignUp} - {RegistrationCommands.SignUp.ToString()}\n");
                string? input = Console.ReadLine();

                // обработка пользовательского ввода
                // если пользователь решил войти - то проверха входа
                if (input == null)
                    Console.WriteLine("Empty input");
                else
                {
                    // проверка на команду входа
                    // commands.SignIn.ToString().ToLower() вернет singin в качестве строки
                    if (input.ToLower() == RegistrationCommands.SignIn.ToString().ToLower() || Convert.ToInt32(input) == ((int)RegistrationCommands.SignIn))
                    {
                        // вход и проверка на его успешность
                        IUser user = SignIn();
                        if (user != null)
                        {
                            User = user;
                            Console.WriteLine($"Hello, {user.Login}\n");
                            return;

                        }
                        else
                            Console.WriteLine("There is no such user");
                    }
                    // проверка на комманду регистрации
                    else if (input.ToLower() == RegistrationCommands.SignUp.ToString().ToLower() || Convert.ToInt32(input) == (int)RegistrationCommands.SignUp)
                    {
                        if (SignUp())
                            Console.WriteLine("New user successfully created. Now Sign In");
                        else
                            Console.WriteLine("There is such user");
                    }
                    else Console.WriteLine("Wrong command. Try again");

                }
            }
            
               
        }

        // регистрация
        private bool SignUp()
        {
            string login, password, fullName, roleInput;
            while(true)
            {
                Console.WriteLine("Enter login");
                login = Console.ReadLine()!;

                if (login != null)
                    break;
                else
                    Console.WriteLine("Empty login");
            }
           

            while (true) 
            {
                Console.WriteLine("Enter password");
                password = Console.ReadLine()!;

                if (password != null)
                    break;
                else
                    Console.WriteLine("Empty password");
            }

            // для проверки на корректность ввода роли
            bool validOutput = false;
            Roles role = default;
            while (true) 
            {
                Console.WriteLine("Enter one of thees roles:\n1 - customer\n2 - seller");
                roleInput = Console.ReadLine()!;

                //если корректный ввод  - устанавливаем соответствующее значение и ставим в переменную выхода значение true
                switch (roleInput)
                {
                    case "1":
                        role = Roles.customer;
                        validOutput = true;
                        break;
                    case "2":
                        role = Roles.seller;
                        validOutput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
                if (validOutput == true)
                    break;
            }

            while (true)
            {
                Console.WriteLine("Enter full name");
                fullName = Console.ReadLine()!;

                if (fullName != null)
                    break;
                else 
                    Console.WriteLine("Empty full name");
            }
            
                
               

            return controller.SignUp(login!,password!,role,fullName!);
        }

        private IUser SignIn()
        {
            string login, password;
            while (true)
            {
                Console.WriteLine("\n\nEnter login");
                login = Console.ReadLine()!;

                if (login != null)
                    break;
                else
                    Console.WriteLine("Empty login");
            }


            while (true)
            {
                Console.WriteLine("\nEnter password");
                password = Console.ReadLine()!;

                if (password != null)
                    break;
                else
                    Console.WriteLine("Empty password");
            }

            IUser? user = controller.SignIn(login, password)!;

            if (user != null)
            {
                Console.WriteLine("");
                return user;
            }
            else
            {
                return null;
            }

        }

        private void InterractionPart()
        {
            while(true) 
            {
                int command = InputCommand();
                switch (command)
                {
                    case (int)CustomerSellerCommands.ProductList:
                        ProductList();
                        break;
                    case (int)CustomerSellerCommands.ProductInfo:
                        ProductInfo();
                        break;
                    case (int)CustomerSellerCommands.AddProductInBucket:
                        AddProductInBucket();
                        break;
                    case (int)CustomerSellerCommands.DeleteProductFromBucket:
                        DeleteProductFromBucket();
                        break;
                    case (int)CustomerSellerCommands.CreateOrder:
                        CreateOrder();
                        break;
                    case (int)CustomerSellerCommands.CancelOrder:
                        CancelOrder();
                        break;
                    case (int)CustomerSellerCommands.ShwoMyOrders:
                        ShwoMyOrders();
                        break;
                    case (int)CustomerSellerCommands.ShowMyBucket:
                        ShowMyBucket();
                        break;
                    case (int)CustomerSellerCommands.ShowMyCertainOrder:
                        ShowMyCertainOrder();
                        break;
                    case (int)CustomerSellerCommands.Help:
                        Help();
                        break;
                    case (int)CustomerSellerCommands.LogOut:
                        LogOut();
                        break;
                    case (int)CustomerSellerCommands.SwitchUser:
                        SwitchUser();
                        break;
                    case (int)AdminCommand.AddUser:
                        AddUser();
                        break;
                    case (int)AdminCommand.DeleteUser:
                        DeleteUser();
                        break;
                    case (int)AdminCommand.ShowAllOrders:
                        ShowAllOrders();
                        break;
                    case (int)AdminCommand.ShowAllUsers:
                        ShowAllUsers();
                        break;
                    case (int)AdminCommand.ShowCertainOrder:
                        ShowCertainOrder();
                        break;
                    case (int)AdminCommand.ShowCertainUser:
                        ShowCertainUser();
                        break;
                    case (int)AdminCommand.ChangeUserInfo:
                        ChangeUserInfo();
                        break;
                }
            }   
        }

        private void ShowCertainUser()
        {
            throw new NotImplementedException();
        }

        private void ShowCertainOrder()
        {
            throw new NotImplementedException();
        }

        private void ShowAllUsers()
        {
            throw new NotImplementedException();
        }

        private void ShowAllOrders()
        {
            throw new NotImplementedException();
        }

        private void DeleteUser()
        {
            throw new NotImplementedException();
        }

        private void AddUser()
        {
            throw new NotImplementedException();
        }

        private void SwitchUser()
        {
            throw new NotImplementedException();
        }

        private void LogOut()
        {
            throw new NotImplementedException();
        }

        private void ShowMyCertainOrder()
        {
            throw new NotImplementedException();
        }

        private void ShowMyBucket()
        {
            if (User == null)
                throw new Exception("Null user");

            Console.WriteLine("\n\n\n");
            if (User.Bucket != null)
            {
                foreach(var pair in User.Bucket)
                {
                    var prod = controller.GetProductById(pair.Key);
                    if (prod == null)
                        throw new Exception("prod in bucket but not in bd. wtf?");

                    WriteSmallProductInfo(prod);
                    Console.WriteLine($"count - {pair.Value}");
                }
            }
            Console.WriteLine("\n\n\n");
        }

        private void ShwoMyOrders()
        {
            throw new NotImplementedException();
        }

        private void CancelOrder()
        {
            throw new NotImplementedException();
        }

        private void CreateOrder()
        {
            throw new NotImplementedException();
        }

        private void DeleteProductFromBucket()
        {
            throw new NotImplementedException();
        }

        private void AddProductInBucket()
        {
            Console.WriteLine("Enter product id");
            var id = Console.ReadLine();
            if (id == null)
            {
                Console.WriteLine("id null. try again");
                return;
            }

            Console.WriteLine("Enter count:");
            var count = Console.ReadLine();
            if (count == null)
            {
                Console.WriteLine("count null. try again");
                return;
            }
            if (controller.AddProductInBucket(Guid.Parse(id), Int32.Parse(count)))
                Console.WriteLine("Product added in bucket");
            else
                Console.WriteLine("There is no such product");

        }


        private void ProductInfo()
        {
            Console.WriteLine("Enter product id:");
            var id = Console.ReadLine();

            var prod = controller.GetProductById(Guid.Parse(id));
            if (prod == null)
                Console.WriteLine("there is no product with such id");
            else
            {
                WriteProductInfo(prod);
            }
            Console.WriteLine("\n\n\n");
        }

        private void WriteSmallProductInfo(Product prod)
        {
            Console.WriteLine($"\n\nproduct name - {prod.Name}\n" +
                $"product id - {prod.Id}");
        }
        private void WriteProductInfo(Product prod)
        {
            Console.WriteLine($"\n\nproduct name - {prod.Name}\n" +
                $"product id - {prod.Id}\n" +
                $"product manufacturer - {prod.Manufacturer}\n" +
                $"product price - {prod.Price}\n" +
                $"in stock? - {(prod.InStock ? "yes" : "no")}\n\n");
        }

        private void ProductList()
        {
            var products = controller.GetAllProducts();

            foreach (var prod in products)
                WriteSmallProductInfo(prod);
        }

        private void Help()
        {
            Console.WriteLine("\n\nCommands list:");

            foreach (var command in commands)
            {
                Console.WriteLine($"{(int)command} - {command}");
            }

            if (User is Admin)
            {
                Console.WriteLine("AdminCommands:\n");
                foreach (var admincommand in adminCommands)
                {
                    Console.WriteLine($"{(int)admincommand} - {admincommand}");
                }
            }

            Console.WriteLine();
        }

        private int InputCommand()
        {
            while(true)
            {
                Help();

                Console.WriteLine("\n Enter command");
                string? command = Console.ReadLine();

                if (commands.Contains((CustomerSellerCommands)Convert.ToInt16(command)) || adminCommands.Contains((AdminCommand)Convert.ToInt16(command)))
                {
                    return Convert.ToInt16(command);
                }
                else
                {
                    Console.WriteLine("try again\n");
                }
            }   
        }

        private void ChangeUserInfo()
        {
            throw new NotImplementedException();
        }


    }
}
