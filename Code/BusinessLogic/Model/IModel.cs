using BusinessLogic.Entities.Products;
using BusinessLogic.Entities.Users;
using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public interface IModel
    {
        public bool SignUp(string Login, string password, Roles role, string fullName);

        public IUser? SignIn(string login, string password);

        public void LogOut();

        public IUser? SwitchUser(string Login, string password);



        public Product? CreateProduct(string name, decimal price, string manufacturer, bool inStock);

        //если какое то поле не изменяется - передавать Null
        public Product? ChangeProductInfo(Guid id, string name, decimal price, string manufacturer, bool inStock);

        public bool DeleteProduct(Guid id);

        public List<Product> GetAllProducts();

        public Product? GetProductById(Guid id);



        public Order? CreateOrder(string byerFullName);

        public Order? CancelOrder(Guid id);

        public Order? GetOrderById(Guid id);

        public List<Order>? GetAllUserOrders(string logIn);



        public IUser? CreateUser(string logIn, string password, Roles role, string fullName);

        public IUser? ChangeUserInfo(string logIn, string newLogIn, string password, string fullName);

        public bool DeleteUser(string logIn);

        public List<IUser>? GetAllUsers();

        public IUser? GetCertainUser(string logIn);



        public bool AddProductInBucket(Guid id, int count);

        public bool DeleteProductInBucket(Guid id);
    }
}
