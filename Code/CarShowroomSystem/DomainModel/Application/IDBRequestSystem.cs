using CarShowroomSystem.Entities;
using CarShowroomSystem.Entities.Products;
using CarShowroomSystem.Entities.Users;
using System.Reflection.Metadata.Ecma335;

namespace CarShowroomSystem.Application
{
    public interface IDBRequestSystem
    {
        bool AddOrder(Order order);
        void AddProduct(Product product);
        bool AddUser(IUser user);
        bool ChangeOrder(Guid id, Order order);
        bool ChangeUserInfo(string login, IUser user);
        bool DeleteUser(string userName);
        bool DeleteProduct(Guid id);
        bool ContainsProductById(Guid id);
        bool ContainsUserByLogIn(string login);


        List<Order>? GetAllOrders();
        List<Product>? GetAllProducts();
        List<IUser>? GetAllUsers();
        IUser? GetCertainUser(string userName);
        Order? GetOrder(Guid id);
        Product? GetProductByGuid(Guid key);
        void AddCar(Car car);
        Car? GetCar(Guid id);
        bool ChangeCarInfo(Guid id, Car car);
        void AddEngineOil(EngineOil engineOil);
        EngineOil? GetEngineOil(Guid id);
        bool ChangeEngineOilInfo(Guid id, EngineOil engineOil);
        void AddTires(Tires tires);
        Tires? GetTires(Guid id);
        public bool ChangeTiresInfo(Guid id, Tires tires);
    }


   










    public class TopDB : IDBRequestSystem
    {
        List<Order> orders;
        List<Product> products;
        List<IUser> users;
        List<Car> cars;
        List<EngineOil> engineOils;
        List<Tires> tireses;

        public TopDB()
        {
            orders = new List<Order>();
            products = new List<Product>();
            users = new List<IUser>();
            cars = new List<Car>();
            tireses= new List<Tires>();
            engineOils= new List<EngineOil>();
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
            List<Product> products = new List<Product>();
            foreach (var car in cars)
                products.Add(car);
            foreach (var engineOil in engineOils)
                products.Add(engineOil);
            foreach (var tire in tireses) 
                products.Add(tire);
            return products;
        }

        public bool AddUser(IUser user)
        {
            if (!ContainsUserByLogIn(user.Login)) 
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
            return users.FirstOrDefault(t => t.Login == userName);
        }

        public List<IUser> GetAllUsers()
        {
            return users;
        }

        public Product? GetProductByGuid(Guid id)
        {
            return products.FirstOrDefault(t => t.Id == id);
        }

        public bool ContainsProductById(Guid id)
        {
            return GetProductByGuid(id) != null;
        }

        public bool ContainsUserByLogIn(string login)
        {
            return GetCertainUser(login) != null;
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public Car? GetCar(Guid id)
        {
            return  cars.FirstOrDefault(t => t.Id == id);
        }

        public bool ChangeCarInfo(Guid id, Car car)
        {
            Car? carr = GetCar(id);

            if (carr is null)
                return false;

            DeleteProduct(id);
            AddCar(car);

            return true;
        }

        public void AddEngineOil(EngineOil engineOil)
        {
            engineOils.Add(engineOil);
        }

        public EngineOil? GetEngineOil(Guid id)
        {
            return engineOils.FirstOrDefault(t => t.Id == id);
        }

        public bool ChangeEngineOilInfo(Guid id, EngineOil engineOil)
        {
            EngineOil? engineOill = GetEngineOil(id);

            if (engineOill is null) 
                return false;

            DeleteProduct(id);
            AddEngineOil(engineOill);

            return true;
        }

        public void AddTires(Tires tires)
        {
            tireses.Add(tires);
        }

        public Tires? GetTires(Guid id)
        {
            return tireses.FirstOrDefault(t => t.Id == id);
        }

        public bool ChangeTiresInfo(Guid id, Tires tires)
        {
            Tires? existingTires = GetTires(id);

            if (existingTires is null)
                return false;

            DeleteProduct(id);
            AddTires(tires);

            return true;
        }

        public bool DeleteProduct(Guid id)
        {
            if (cars.FirstOrDefault(t => t.Id == id) is not null)
            {
                cars.Remove(GetCar(id)!);
                return true;
            }
            else if (engineOils.FirstOrDefault(t => t.Id == id) is not null)
            {
                engineOils.Remove(GetEngineOil(id)!);
                return true;
            }
            else if (tireses.FirstOrDefault(t => t.Id == id) is not null)
            {
                tireses.Remove(GetTires(id)!);
                return true;
            }

            return false;
        }
    }

}
