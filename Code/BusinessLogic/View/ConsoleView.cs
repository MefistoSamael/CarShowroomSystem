using BusinessLogic.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.View
{
    public class ConsoleView
    {
        Controller.Controller controller;
        public ConsoleView(Controller.Controller controller) 
        {
            this.controller = controller;
            Main();
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
                Console.WriteLine("\n1 - Sign In\n2 - Sign Up\n");
                string? input = Console.ReadLine();

                // обработка пользовательского ввода
                // если пользователь решил войти - то проверха входа
                if (input == "Sign In")
                {
                    // вход и проверка на его успешность
                    IUser user = SignIn();
                    if (user != null)
                    {
                        Console.WriteLine($"Hello, {user.Login}\n");
                        break;
                    }
                    else
                        Console.WriteLine("There is no such user");
                }
                else if (input == "Sign Up")
                {
                    if (SignUp())
                        Console.WriteLine("New user successfully created. Now Sign In");
                    else
                        Console.WriteLine("There is such user");
                }
                else Console.WriteLine("Wrong command. Try again");
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
            throw new NotImplementedException();
        }

    }
}
