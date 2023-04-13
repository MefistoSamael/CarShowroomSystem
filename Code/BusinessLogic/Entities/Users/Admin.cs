using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities.Users
{
    internal class Admin : IUser
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public List<Guid>? Bucket { get; private set; }

        public Order? CurrentOrder { get; private set; }

        public Roles Role { get; private set; }

        public Admin(string login, string password, List<Order> userOrders, List<Guid> bucket)
        {
            Login = login;
            Password = password;
            Bucket = bucket;
            Role = Roles.admin;
        }


        public void CancelOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(string buyerFullName)
        {
            throw new NotImplementedException();
        }

        public void CancelAnyOrder(Order order)
        {
            orderHandleSystem.FinishOrder(order);
        }
        public void DeleteUser(string login)
        {
            if (!userControlSystem.DeleteUser(login))
            {
                //не удалось удалить пользователя
            }
        }

        public void CreateUser(string login, string password, Roles role)
        {
            if (!userControlSystem.CreateUser(login, password, role))
            {
                //не удалось создать пользователя
            }

        }
    }
}
