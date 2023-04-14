using BusinessLogic.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities.Users
{
    public class Seller : IUser
    {
        public OrderHandleSystem orderHandleSystem { get; }

        public string Login { get; set; }

        public string Password { get; set; }

        public List<Guid>? Bucket { get; private set; }

        public Roles Role { get; private set; }
        public string FullName { get; set; }

        public Seller(string login, string password, List<Order> userOrders, List<Guid> bucket, string fullName, OrderHandleSystem orderHandleSystem)
        {
            Login = login;
            Password = password;
            Bucket = bucket;
            Role = Roles.seller;
            FullName = fullName;
            this.orderHandleSystem = orderHandleSystem;
        }

        public bool CancelOrder(Guid id)
        {
            return orderHandleSystem.ReturnOrder(id);
        }

        public Order CreateOrder(string buyerFullName)
        {
            return orderHandleSystem.CreateOrder(Login, buyerFullName, Bucket);
        }
    }

}
