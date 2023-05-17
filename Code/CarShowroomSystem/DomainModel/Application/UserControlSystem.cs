using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShowroomSystem.Entities.Users;

namespace CarShowroomSystem.Application
{
    public class UserControlSystem
    {
        public CustomerRequestHandler? customerRequestHandler { get; internal set; }

        public OrderHandleSystem? orderHandleSystem { get; internal set; }

        public IDBRequestSystem? DB { get; internal set; }

        public UserControlSystem()
        {
            customerRequestHandler = null;
            orderHandleSystem = null;
            DB = null;
        }

        public IUser? CreateUser(string login, string password, Roles role, string fullName)
        {
            ConnectionCheck();

            IUser? user = null;
            //Создание пользователя в зависимости от роли
            switch (role)
            {
                case Roles.customer:
                    user = new Customer(login, password, new Dictionary<Guid, int>(), fullName, orderHandleSystem!);
                    break;

                case Roles.seller:
                    user = new Seller(login, password, new Dictionary<Guid, int>(), fullName, orderHandleSystem!);
                    break;

                case Roles.admin:
                    user = new Admin(login, password, new Dictionary<Guid, int>(), fullName, orderHandleSystem!, this);
                    break;

                default:
                    throw new Exception("Добавлена новая необработанная роль");
                    //break;
            }

            if (!DB!.AddUser(user))
                return null;

            return user;
        }

        // удаляем пользователя
        public bool DeleteUser(string login)
        {
            ConnectionCheck();

            return DB!.DeleteUser(login);
        }

        // изменяем информацию о пользователе
        public IUser? ChangeUserInfo(string login, string newLogin, string password, string fullName)
        {
            ConnectionCheck();

            IUser? user = DB!.GetCertainUser(login);
            // если пользователя не существует возвращаем false
            if (user == null) return null;

            //тернарное выражение, проверяющее изменение соответствующего поля
            user.Login = newLogin == null ? user.Login : newLogin;
            user.Password = password == null ? user.Password : password;
            user.FullName = fullName == null ? user.FullName : fullName;

            DB.ChangeUserInfo(login, user);

            return user;
        }

        // устанавливает поле currentUser в CustomerRequestHandler
        public bool LogIn(string login, string password) 
        {
            ConnectionCheck();

            // получаем пользователя
            IUser? user = DB!.GetCertainUser(login);
            // если такого пользователя не существует - возвращаем false
            if (user == null || user.Password != password) return false;

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

        public bool SwitchUser(string login, string password)
        {
            ConnectionCheck();

            if (customerRequestHandler!.CurrentUser != null) LogOut();
            return LogIn(login, password);
        }

        //проверка подключения БД и CustomerRequestHandler
        //нужна просто чтобы не забыть про подключение
        private void ConnectionCheck()
        {
            if (DB == null) throw new Exception("У тебя база данных null, дурашка");
            if (customerRequestHandler == null) throw new Exception("У тебя customerRequestHandler null, дурашка");
            if (orderHandleSystem == null) throw new Exception("У тебя orderHandleSystem null, дурашка");
        }

    }
}
