using BusinessLogic.Application;
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
        public OrderHandleSystem orderHandleSystem { get; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Dictionary<Guid, int> Bucket { get; }

        public string FullName{ get; set; }


        public Roles Role { get; }

        public void AddProductInBucket(Guid id, int count = 1)
        {
            if (Bucket.ContainsKey(id)) Bucket[id] += count;
            else Bucket[id] = count;
        }
        public void DeleteProductInBucket(Guid id)
        {
            Bucket.Remove(id);
        }

        public Order CreateOrder(string buyerFullName);
        public Order? CancelOrder(Guid id);
    }
}