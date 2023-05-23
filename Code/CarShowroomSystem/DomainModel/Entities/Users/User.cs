using CarShowroomSystem.Application;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public enum Roles
{
    customer =0,
    seller = 1,
    admin = 2,
}

namespace CarShowroomSystem.Entities.Users
{
    public interface IUser
    {
        public OrderHandleSystem orderHandleSystem { get; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Dictionary<Guid, int> Bucket { get; set; }

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