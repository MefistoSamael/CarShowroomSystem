using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities.Users;

namespace BusinessLogic.Application
{
    public class UserControlSystem
    {
        public CustomerRequestHandler? customerRequestHandler { get; internal set; }

        public IDBRequestSystem? DB { get; internal set; }

        public UserControlSystem()
        {
            customerRequestHandler = null;
            DB = null;
        }

        public bool CreateUser(string login, string password, Roles role)
        {
            ConnectionCheck();

            IUser? user = null;
            //Создание пользователя в зависимости от роли
            switch (role)
            {
                case Roles.customer:
                    user = new Customer(login, password, new List<Entities.Order>(), new List<Guid>());
                    break;

                case Roles.seller:
                    user = new Seller(login, password, new List<Entities.Order>(), new List<Guid>());
                    break;

                case Roles.admin:
                    user = new Admin(login, password, new List<Entities.Order>(), new List<Guid>());
                    break;

                default:
                    throw new Exception("Добавлена новая необработанная роль");
                    //break;
            }

            return DB.AddUser(user);
        }

        // удаляем пользователя
        public bool DeleteUser(string login)
        {
            ConnectionCheck();

            return DB!.DeleteUser(login);
        }

        // изменяем информацию о пользователе
        public bool ChangeUserInfo(string login, string newLogin, string password)
        {
            ConnectionCheck();

            IUser? user = DB!.GetCertainUser(login);
            // если пользователя не существует возвращаем false
            if (user == null) return false;

            //тернарное выражение, проверяющее изменение соответствующего поля
            user.Login = newLogin == null ? user.Login : newLogin;
            user.Password = password == null ? user.Password : password;

            return DB.ChangeUserInfo(login, user);
        }

        // устанавливает поле currentUser в CustomerRequestHandler
        public bool LogIn(string login) 
        {
            ConnectionCheck();

            // получаем пользователя
            IUser? user = DB!.GetCertainUser(login);
            // если такого пользователя не существует - возвращаем false
            if (user == null) return false;

            //устанавливаем пользователя
            customerRequestHandler!.CurrentUser = user;
            return true;
        }

        // устанавливает в поле currentUser значение null
        public void LogOut()
        {
            ConnectionCheck();

            customerRequestHandler!.CurrentUser = null;
        }

        public bool SwitchUser(string login)
        {
            ConnectionCheck();

            if (customerRequestHandler!.CurrentUser != null) LogOut();
            return LogIn(login);
        }

        //проверка подключения БД и CustomerRequestHandler
        //нужна просто чтобы не забыть про подключение
        private void ConnectionCheck()
        {
            if (DB == null) throw new Exception("У тебя база данных null, дурашка");
            if(customerRequestHandler == null) throw new Exception("У тебя customerRequestHandler null, дурашка");
        }

    }
}
