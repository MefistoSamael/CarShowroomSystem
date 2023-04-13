using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities.Users
{
    internal class Customer : IUser
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public List<Order>? UserOrders { get; private set; }

        public List<Guid>? Bucket { get; private set; }

        public Order? CurrentOrder { get; private set; }

        public Roles Role { get; private set; }

        public Customer(string login, string password, List<Order> userOrders, List<Guid> bucket)
        {
            Login = login;
            Password = password;
            Bucket = bucket;
            Role = Roles.customer;
        }

        public void CreateOrder(string buyerFullName)
        {
            throw new NotImplementedException();
        }

        public void CancelOrder(Order order)
        {
            throw new NotImplementedException();
        }

    }
}
