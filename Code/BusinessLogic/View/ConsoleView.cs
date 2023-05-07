using BusinessLogic.Entities;
using BusinessLogic.Entities.Products;
using BusinessLogic.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.AccessControl;
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
                    case (int)AdminCommand.AddCar:
                        AddCar();
                        break;
                    case (int)AdminCommand.DeleteCar:
                        DeleteCar();
                        break;
                    case (int)AdminCommand.ChangeCarInfo:
                        ChangeCarInfo();
                        break;
                    case (int)AdminCommand.AddEngineOil:
                        AddEngineOil();
                        break;
                    case (int)AdminCommand.DeleteEngineOil:
                        DeleteEngineOil();
                        break;
                    case (int)AdminCommand.ChangeEngineOilInfo:
                        ChangeEngineOilInfo();
                        break;
                    case (int)AdminCommand.AddTires:
                        AddTires();
                        break;
                    case (int)AdminCommand.DeleteTires:
                        DeleteTires();
                        break;
                    case (int)AdminCommand.ChangeTiresInfo:
                        ChangeTiresInfo();
                        break;
                }
            }   
        }

        private void ChangeTiresInfo()
        {
            throw new NotImplementedException();
        }

        private void DeleteTires()
        {
            throw new NotImplementedException();
        }

        private void AddTires()
        {
            throw new NotImplementedException();
        }

        private void ChangeEngineOilInfo()
        {
            throw new NotImplementedException();
        }

        private void DeleteEngineOil()
        {
            throw new NotImplementedException();
        }

        private void AddEngineOil()
        {
            throw new NotImplementedException();
        }

        private void ChangeCarInfo()
        {
            throw new NotImplementedException();
        }

        private void DeleteCar()
        {
            throw new NotImplementedException();
        }

        private void AddCar()
        {
            throw new NotImplementedException();
        }

        private void ChangeUserInfo()
        {
            throw new NotImplementedException();
        }

        private void ShowCertainUser()
        {
            throw new NotImplementedException();
        }

        private void ShowCertainOrder()
        {
            Guid id = EnterId();
        }

        private Guid EnterId()
        {
            while (true)
            {
                Console.WriteLine("Enter id");

                string? id = Console.ReadLine();

                if (id is null)
                {
                    Console.WriteLine("id null. Try again");
                    continue;
                }

                try
                {
                    Guid guid = Guid.Parse(id);
                }
                catch
                {
                    Console.WriteLine("Invalid id. try again");
                }
            }
        }

        private void ShowAllUsers()
        {
            List<IUser>? users = controller.GetAllUsers();

            if (users is null)
            {
                NoUsersHandle();
                return;
            }

            foreach (var user in users)
                WriteUser(user);
        }

        private void WriteUser(IUser user)
        {
            Console.WriteLine("User info:");
            Console.WriteLine($"Login:\t\t{user.Login}");
            Console.WriteLine($"Password:\t{user.Password}");
            Console.WriteLine($"Full Name\t{user.FullName}");
            Console.WriteLine($"Role:\t\t{user.Role}");

            Console.WriteLine("Bucket:");
            WriteBucket(user.Bucket);
            Console.WriteLine();

        }

        private void NoUsersHandle()
        {
            Console.WriteLine("there is no users");
        }

        private void ShowAllOrders()
        {
            List<Order>? orders = controller.GetAllOrders();

            if (orders is null)
            {
                NoOrdesHandle();
                return;
            }
            
            foreach (var order in orders)
                WriteOrder(order);

        }

        private void NoOrdesHandle()
        {
            Console.WriteLine("there is no orders");
        }

        private void DeleteUser()
        {
            string logIn= EnterLogIn();

            if (!controller.DeleteUser(logIn))
                UnknownLogin(); 
        }

        private void UnknownLogin()
        {
            Console.WriteLine("there is no user with such login");
        }

        private string EnterLogIn()
        {
            Console.WriteLine("Enter login");
            string? login = Console.ReadLine();
            while (true)
            {
                if (login == null)
                {
                    Console.WriteLine("E\nN\nT\nE\nR\nL\nO\nG\nI\nN\n");
                    login= Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            return login;
        }

        private void AddUser()
        {
            string login, password, fullName, roleInput;
            while (true)
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

            controller.AddUser(login, password, role, fullName);
        }

        private void SwitchUser()
        {
            if (User == null)
                throw new Exception(" user is null");

            controller.LogOut();
            User = null;


            while (true)
            {
                // без приведения к int выведет SignIn
                Console.WriteLine($"\n{(int)RegistrationCommands.SignIn} - {RegistrationCommands.SignIn.ToString()}\n");
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
                    else Console.WriteLine("Wrong command. Try again");

                }
            }

        }

        private void LogOut()
        {
            if (User == null)
                throw new Exception(" user is null");

            controller.LogOut();
            User= null;

            AuthorizationPart();
        }

        private void ShowMyCertainOrder()
        {
            if (User == null)
                throw new Exception("Null user");

            Console.WriteLine("Enter order id");
            var id = Console.ReadLine();
            if (id == null)
            {
                Console.WriteLine("id null. try again");
                return;
            }

            if (controller.GetOrderById(Guid.Parse(id)) == null)
            { 
                Console.WriteLine("Wrong id or that's not your order"); 
            }
        }

        private void ShowMyBucket()
        {
            if (User == null)
                throw new Exception("Null user");

            Console.WriteLine("\n\n\n");
            if (User.Bucket != null)
            {
                WriteBucket(User.Bucket);
            }
            Console.WriteLine("\n\n\n");
        }

        private void WriteBucket(Dictionary<Guid, int> bucket)
        {
            if (bucket.Count == 0)
                Console.WriteLine("bucket is empty");
            else
                foreach (var pair in bucket)
                {
                    var prod = controller.GetProductById(pair.Key);
                    if (prod == null)
                        throw new Exception("prod in bucket but not in bd. wtf?");

                    WriteSmallProductInfo(prod);
                    Console.WriteLine($"count\t{pair.Value}");
                }
        }

        private void ShwoMyOrders()
        {
            if (User == null) throw new Exception("user is null");

            var orders = controller.GetAllUserOrders(User.Login);

            if(orders == null)
                Console.WriteLine("there is no orders for that user");
            else
            {
                foreach (var order in orders)
                    WriteOrder(order);
            }
        }

        private void WriteOrder(Order order)
        {
            Console.WriteLine($"" +
                $"order id - {order.Id}\n" +
                $"creator user name - {order.CreatorUserName}\n" +
                $"buyer full name - {order.BuyerFullName}\n" +
                $"price - {order.Price}\n" +
                $"order state - {order.State}\n" +
                $"creation time - {order.CreationTime}\n");
            if (order.State == Order.OrderState.Returned)
                Console.WriteLine($"cancellation time - {order.CancellationTime}");

            Console.WriteLine("Products in bucket");
            foreach (var item in order.Bucket)
            {
                WriteSmallProductInfo(controller.GetProductById(item.Key)!);
            }

            Console.WriteLine("\n\n\n");

        }

        private void CancelOrder()
        {
            if (User == null)
                throw new Exception("User is null");

            Console.WriteLine("Enter order id");
            var id = Console.ReadLine();
            if (id == null)
            {
                Console.WriteLine("id null. try again");
                return;
            }

            if (controller.CancelOrder(Guid.Parse(id)) == null)
            {
                Console.WriteLine("There is no order with such id");
                return;
            }
        }

        private void CreateOrder()
        {
            if (User == null)
                throw new Exception("User is null");

            string? byerFullName = User.FullName;

            // если оформляет заказ не покупатель, то необходимо ввести имя того, кто
            // покупает "в реальности"(из предметной области)
            if (User is Admin || User is Seller)
            {
                Console.WriteLine("Enter byer full name");
                byerFullName = Console.ReadLine();
                if (byerFullName == null)
                {
                    Console.WriteLine("byer full name is null. try again");
                    return;
                }
            }


            if (controller.CreateOrder(byerFullName) == null)
            {
                Console.WriteLine("bucket is empty");
                return;
            }
        }

        private void DeleteProductFromBucket()
        {
            Console.WriteLine("Enter product id");
            var id = Console.ReadLine();
            if (id == "")
            {
                Console.WriteLine("id empty. try again");
                return;
            }

            if (controller.DeleteProductInBucket(Guid.Parse(id)))
                Console.WriteLine("Product deleted from bucket");
            else
                Console.WriteLine("There is no element with such id");
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
            Console.WriteLine($"\n\nproduct name\t{prod.Name}\n" +
                $"product id\t\t{prod.Id}");
        }
        private void WriteProductInfo(Product prod)
        {
            Console.WriteLine($"\n\nproduct name\t\t\t{prod.Name}\n" +
                $"product id\t\t\t{prod.Id}\n" +
                $"product manufacturer\t{prod.Manufacturer}\n" +
                $"product price\t\t{prod.Price}\n" +
                $"in stock?\t\t\t{(prod.InStock ? "yes" : "no")}\n\n");
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

    }
}
