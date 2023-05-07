using BusinessLogic.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities.Users
{
    internal class Admin : IUser
    {
        public OrderHandleSystem orderHandleSystem { get; }

        public UserControlSystem userControlSystem { get; }
        public string Login { get; set; }

        public string Password { get; set; }

        public Dictionary<Guid, int> Bucket { get; set; }

        public Roles Role { get; private set; }

        public string FullName { get; set; }

        public Admin(string login, string password, Dictionary<Guid, int> bucket, string fullName, OrderHandleSystem orderHandleSystem, UserControlSystem userControlSystem)
        {
            Login = login;
            Password = password;
            Bucket = bucket;
            Role = Roles.admin;
            FullName = fullName;
            this.orderHandleSystem = orderHandleSystem;
            this.userControlSystem = userControlSystem;
        }


        public Order? CancelOrder(Guid id)
        {
            return orderHandleSystem.ReturnOrder(id);
        }

        public Order CreateOrder(string buyerFullName)
        {
            return orderHandleSystem.CreateOrder(Login, Login, Bucket);
        }

        public bool DeleteUser(string login)
        {
            if (!userControlSystem.DeleteUser(login))
            {
                return false;
            }
            return true;
        }

        public bool CreateUser(string login, string password, Roles role, string FullName)
        {
            if (userControlSystem.CreateUser(login, password, role, FullName) != null)
            {
                return false;
            }
            return true;
        }
    }
}
