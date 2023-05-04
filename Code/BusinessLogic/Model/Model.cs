using BusinessLogic.Application;
using BusinessLogic.Entities;
using BusinessLogic.Entities.Products;
using BusinessLogic.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class Model : IModel
    {
        private UserControlSystem userControlSystem;
        private CustomerRequestHandler customerRequestHandler;
        private OrderHandleSystem orderHandleSystem;
        private ProductCreator productCreator;
        private IDBRequestSystem dBRequestSystem;

        public IUser? currentUser;
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

        public void LogOut()
        {
            userControlSystem.LogOut();
            currentUser = null;
        }

        public IUser? SwitchUser(string Login, string password)
        {
            userControlSystem.SwitchUser(Login, password);
            return currentUser = customerRequestHandler.CurrentUser;
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
            SignUp("Ivan228336", "1234", Roles.customer, "Ivan  Zalupko");
            SignUp("AnotonioPripizduchi666", "1234", Roles.seller, "Anotonio Pripizduchi");
            SignUp("SexMachine1337", "1234", Roles.admin, "Daniil Gryaznii");
        }

        public bool SignUp(string logIn, string password, Roles role, string fullName)
        {
            return userControlSystem.CreateUser(logIn, password, role, fullName) == null ? true : false;
        }

        public IUser? SignIn(string logIn, string password)
        {
            userControlSystem.LogIn(logIn, password);
            return currentUser = customerRequestHandler.CurrentUser;
        }

        public Product CreateProduct(string name, decimal price, string manufacturer, bool inStock)
        {
            return productCreator.CreateProduct(new Guid(), name, manufacturer, inStock, price);
        }

        public Product ChangeProductInfo(Guid id, string name, decimal price, string manufacturer, bool inStock)
        {
            throw new Exception("will be added sooner");
        }

        public bool DeleteProduct(Guid id)
        {
            throw new Exception("will be added sooner");
        }

        public Product GetProductById(Guid id)
        {
            throw new Exception("will be added sooner");
        }

        public Order CreateOrder(string byerFullName)
        {
            currentUserCheck();

            return orderHandleSystem.CreateOrder(currentUser!.Login, byerFullName, currentUser.Bucket);
        }

        public Order? CancelOrder(Guid id)
        {
            currentUserCheck();

            // получаем заказа, чтобы сделать проверку на допустимость отмены заказа
            // по задумке заказа может отменить только пользователь его создавший или адиминистратор
            Order? order = dBRequestSystem.GetOrder(id);

            if (order == null)
                return null;

            // если отмена происходит пользователем не сделавшим заказ и он не админ
            // то где то произошла ошибка
            if (correctUserCheck(order.CreatorUserName))
                return orderHandleSystem.ReturnOrder(id);
            else
                throw new Exception("Order cancellation from wrong user (not admin or not creator of order");

            
        }

        public Order? GetOrderById(Guid id)
        {
            currentUserCheck();

            Order? order = dBRequestSystem.GetOrder(id);

            if (order == null)
                return null;

            // если пользователь пытается получить не свой заказ - это ошибка в вышестоящем модуле(представление или контроллер)
            // поскольку покупатель и продавец - должны знать только о своих заказах
            if (correctUserCheck(order.CreatorUserName))
                return dBRequestSystem.GetOrder(id);
            else
                throw new Exception("Order acces from wrong user (not admin or not creator of order)");

        }

        public List<Order> GetAllUserOrders(string logIn)
        {
            currentUserCheck();

            // если пользователь пытается получить не свой заказ - это ошибка в вышестоящем модуле(представление или контроллер)
            // поскольку покупатель и продавец - должны знать только о своих заказах
            if (correctUserCheck(logIn))
                //при помощи linQ запроса получаем заказы где userName(login) создателя равен интересующему на логину
                return dBRequestSystem.GetAllOrders().Where((Order order) => order.CreatorUserName == logIn).ToList();
            else throw new Exception("Order acces from wrong user (not admin or not creator of order)");
        }

        public IUser? CreateUser(string logIn, string password, Roles role, string fullName)
        {
            // создание пользователя доступно в двух случаях:
            // 1) админ создает пользователя
            // 2) пользователь создается заранее для демонстрации работы программы
            if (currentUser == null || currentUser is Admin)
                return userControlSystem.CreateUser(logIn, password, role, fullName);
            else
                throw new Exception("Invalid user creation attempt");
        }

        public IUser? ChangeUserInfo(string logIn, string newLogIn, string password, string fullName)
        {
            if (currentUser is Admin)
                return userControlSystem.ChangeUserInfo(logIn, newLogIn, password, fullName);
            else 
                throw new Exception("Invalid user change attempt");
        }

        public bool DeleteUser(string logIn)
        {
            if (currentUser is Admin)
                return userControlSystem.DeleteUser(logIn);
            else
                throw new Exception("Invalid user delete attempt");
        }

        public IUser? GetCertainUser(string logIn)
        {
            if (currentUser is Admin)
                return dBRequestSystem.GetCertainUser(logIn);
            else 
                throw new Exception("Invalid user get attempt");
        }

        public void AddProductInBucket(Guid id)
        {
            currentUserCheck();

            currentUser!.AddProductInBucket(id); 
        }

        public void DeleteProductInBucket(Guid id)
        {
            currentUserCheck();

            currentUser!.DeleteProductInBucket(id);
        }

        private void currentUserCheck()
        {
            if (currentUser == null)
                throw new Exception("Error: user isnt loginned");
        }

        // проверяет явялется ли переданный пользователь корректным (для случая работы с заказом)
        private bool correctUserCheck(string creatorUserName) => currentUser is Admin || currentUser!.Login == creatorUserName;
    }
}
