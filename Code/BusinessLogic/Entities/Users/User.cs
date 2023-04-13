using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public enum Roles
{
    customer = 1,
    seller = 2,
    admin = 3
}

namespace BusinessLogic.Entities.Users
{
    public interface IUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Guid>? Bucket { get; }
        public Order? CurrentOrder { get; }


        public Roles Role { get; }

        public void AddProductInBucket(Guid id)
        {
            Bucket.Add(id);
        }
        public void DeleteProductInBucket(Guid id)
        {
            Bucket.Remove(id);
        }

        public void CreateOrder(string buyerFullName);
        public void CancelOrder(Order order);
    }
}