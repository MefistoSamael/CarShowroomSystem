using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities.Products
{
    internal class Product
    {
        public Product()
        {
            Id = new Guid();
            Name = "";
            Price = 0;
            Manufacturer = "";
            InStock = false;

        }

        public Product(Guid id, string name, decimal price, string manufacturer, bool inStock)
        {
            Id = id;
            Name = name;
            Price = price;
            Manufacturer = manufacturer;
            InStock = inStock;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Manufacturer { get; set; }

        public bool InStock { get; set; }

    }
}
