using CarShowroomSystem.Entities;
using CarShowroomSystem.Entities.Users;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;


public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Установите строку подключения к базе данных SQL Server
        string connectionString = "Server=<DESKTOP-J6CKC82\\SQLEXPRESS>;Database=<CarShowRoom>;Trusted_Connection=true;";

        optionsBuilder.UseSqlServer(connectionString);
    }
}

public class OrderRepository
{
    private readonly Order context;

    public OrderRepository()
    {
        context = new Order();
    }
    public bool AddOrder(Order order)
    {
        if (!context.Orders.Contains(order))
        {
            context.Orders.Add(order);
            context.SaveChanges();
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

}



























































//using Microsoft.Data.Sqlite;
//using Entity.Framewrk.Core
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace CarShowroomSystem
//{
//    internal class DataBase
//    {

//        static SQLiteAsyncConnection Database;

//       public void CreateDataBase()
//       {
//            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

//        }
//    }


//    public static class Constants
//    {
//        public const string DatabaseFilename = "TodoSQLite.db3";

//        public const SQLite.SQLiteOpenFlags Flags =
//            // open the database in read/write mode
//            SQLite.SQLiteOpenFlags.ReadWrite |
//            // create the database if it doesn't exist
//            SQLite.SQLiteOpenFlags.Create |
//            // enable multi-threaded database access
//            SQLite.SQLiteOpenFlags.SharedCache;

//        public static string DatabasePath
//        {
//            get
//            {
//                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
//                return Path.Combine(basePath, DatabaseFilename);
//            }
//        }
//    }
//}
