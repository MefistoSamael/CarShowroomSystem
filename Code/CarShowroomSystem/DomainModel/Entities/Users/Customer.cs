﻿using CarShowroomSystem.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomSystem.Entities.Users
{
    internal class Customer : IUser
    {
        public OrderHandleSystem orderHandleSystem { get; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Dictionary<Guid, int> Bucket { get; set; }

        public Roles Role { get; private set; }
        public string FullName { get; set; }

        public Customer(string login, string password, Dictionary<Guid, int> bucket, string fullName, OrderHandleSystem orderHandleSystem)
        {
            Login = login;
            Password = password;
            Bucket = bucket;
            Role = Roles.customer;
            FullName = fullName;
            this.orderHandleSystem = orderHandleSystem;
        }

        public Order? CancelOrder(Guid id)
        {
            return orderHandleSystem.ReturnOrder(id);
        }

        public Order CreateOrder(string buyerFullName)
        {
            return orderHandleSystem.CreateOrder(Login, Login, Bucket);
        }
    }
}
