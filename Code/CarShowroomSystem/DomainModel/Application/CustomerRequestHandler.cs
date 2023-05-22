using CarShowroomSystem.Entities;
using CarShowroomSystem.Entities.Users;
using System.Data;

namespace CarShowroomSystem.Application
{
    public class CustomerRequestHandler
    {
        public IUser? CurrentUser { get; set; }
        public UserControlSystem? userControlSystem { get; internal set; }
        public CustomerRequestHandler()
        {
            CurrentUser= null;
            userControlSystem = null;
        }

        public Order CreateOrder(string byerFullName)
        {
            UserCheck();

            return CurrentUser!.CreateOrder(byerFullName);
        }

        public Order? CancelOrder(Guid id)
        {
            UserCheck();

            return CurrentUser!.CancelOrder(id);
        }

        // создание пользователя админом
        public IUser? CreateUser(string login, string password, Roles role, string fullName)
        {
            UserCheck();
            UserControlSystemCheck();

            if (CurrentUser is Admin)
                return userControlSystem!.CreateUser(login, password, role, fullName);
            else
                return null;
        }

        // удаление пользователя админом
        public bool DeleteUser(string login)
        {
            UserControlSystemCheck();

            if (CurrentUser is Admin)
                return userControlSystem!.DeleteUser(login);
            else
                return false;
        }


        // проверка на подключенность пользователя
        void UserCheck()
        {
            if (CurrentUser == null) throw new Exception("У тебя user Null дурашка");
        }

        // проверка на подключенность UserControlSystem
        void UserControlSystemCheck()
        {
            if (userControlSystem == null) throw new Exception("У тебя userControlSystem Null дурашка");
        }
    }
}