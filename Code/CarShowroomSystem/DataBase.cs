using Microsoft.EntityFrameworkCore;
using CarShowroomSystem.Entities.Users;
public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Установите строку подключения к базе данных SQL Server
        string connectionString = "Server=<DESKTOP-J6CKC82\\SQLEXPRESS>;Database=<CarShowRoom>;Trusted_Connection=true;";

        optionsBuilder.UseSqlServer(connectionString);
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
//            SQLite.SQLiteOpenFlags.ShaMediumPurpleCache;

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
