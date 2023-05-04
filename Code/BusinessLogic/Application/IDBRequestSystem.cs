using BusinessLogic.Entities;
using BusinessLogic.Entities.Products;
using BusinessLogic.Entities.Users;
using System.Reflection.Metadata.Ecma335;

namespace BusinessLogic.Application
{
    public interface IDBRequestSystem
    {
        bool AddOrder(Order order);
        void AddProduct(Product product);
        bool AddUser(IUser user);
        bool ChangeOrder(Guid id, Order order);
        bool ChangeUserInfo(string login, IUser user);
        bool DeleteUser(string userName);
        List<Order> GetAllOrders();
        List<Product> GetAllProducts();
        List<IUser> GetAllUsers();
        IUser? GetCertainUser(string userName);
        Order? GetOrder(Guid id);
    }

    public class TopDB : IDBRequestSystem
    {
        List<Order> orders;
        List<Product> products;
        List<IUser> users;

        public TopDB()
        {
            orders = new List<Order>();
            products = new List<Product>();
            users = new List<IUser>();
        }
        public bool AddOrder(Order order)
        {
            if (!orders.Contains(order))
            {
                orders.Add(order);
                return true;
            }
            return false;
        }

        public bool ChangeOrder(Guid id, Order order)
        {
            var item = GetOrder(id);
            if (item == null)
                return false;

            DeleteOrder(id);
            AddOrder(order);
            return true;
        }

        public bool DeleteOrder(Guid id)
        {
            var item = orders.Where(t => t.Id == id).FirstOrDefault();
            if (item != null)
            {
                return orders.Remove(item);
            }
            else
            {
                return false;
            }
        }

        public Order? GetOrder(Guid id)
        {
            return orders.Where(t => t.Id == id).FirstOrDefault();
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public bool AddUser(IUser user)
        {
            if (!users.Contains(user)) 
            {
                users.Add(user);
                return true;
            }
            return false;
        }

        public bool ChangeUserInfo(string login, IUser user)
        {
            var item = GetCertainUser(login);
            if (item == null) 
                return false;

            DeleteUser(login);
            AddUser(user);
            return true;
        }

        public bool DeleteUser(string userName)
        {
            var item = users.Where(t => t.Login == userName).FirstOrDefault();
            if (item != null)
            {
                return users.Remove(item);
            }
            else 
            {
                return false;
            }
        }

        public IUser? GetCertainUser(string userName)
        {
            return users.Where(t => t.Login== userName).FirstOrDefault();
        }

        public List<IUser> GetAllUsers()
        {
            return users;
        }

    }

}
