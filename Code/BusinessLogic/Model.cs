using BusinessLogic.Application;
using BusinessLogic.Entities;
using BusinessLogic.Entities.Products;
using BusinessLogic.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Model
    {
        private UserControlSystem userControlSystem;
        private CustomerRequestHandler customerRequestHandler;
        private OrderHandleSystem orderHandleSystem;
        private ProductCreator productCreator;
        private IDBRequestSystem dBRequestSystem;
        public IUser currentUser;

        public Model() 
        {
            dBRequestSystem = new TopDB();
            userControlSystem = new UserControlSystem();
            customerRequestHandler = new CustomerRequestHandler();
            orderHandleSystem = new OrderHandleSystem();
            productCreator = new ProductCreator();

            // установка всех зависимостей

            //userControlSystem
            userControlSystem.customerRequestHandler = customerRequestHandler;
            userControlSystem.orderHandleSystem = orderHandleSystem;
            userControlSystem.DB = dBRequestSystem;

            //CustomerRequestHandler
            customerRequestHandler.userControlSystem = userControlSystem;

            //OrderHandleSystem
            orderHandleSystem.DB = dBRequestSystem;

            //ProductCreator
            productCreator.db = dBRequestSystem;
            
            productCreator.Demonstration();
            Demonstration();
        }

        public bool Registrate(string Login, string password, Roles role, string fullName)
        {
            return userControlSystem.CreateUser(Login, password, role, fullName);
        }

        public bool LogIn(string Login, string password)
        {
            var b = userControlSystem.LogIn(Login, password);
            currentUser = customerRequestHandler.CurrentUser;
            return b;
        }

        public bool DeletUser(string login)
        {
            return customerRequestHandler.DeleteUser(login);
        }

        public List<Product> GetAllProducts()
        {
            return dBRequestSystem.GetAllProducts();
        }

        public List<IUser> GetAllUsers()
        {
            return dBRequestSystem.GetAllUsers();
        }

        public List<Order> GetAllOrders() 
        {
            return dBRequestSystem.GetAllOrders();
        }

        public void Demonstration()
        {
            Registrate("Ivan228336", "1234", Roles.customer, "Ivan  Zalupko");
            Registrate("AnotonioPripizduchi666", "1234", Roles.seller, "Anotonio Pripizduchi");
            Registrate("SexMachine1337", "1234", Roles.admin, "Daniil Gryaznii");


        }
        //public bool AddOrder()
        //{

        //}

        //public bool CancelOrder()
        //{

        //}


    }
}
