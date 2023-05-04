using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities.Products;

namespace BusinessLogic.Application
{
    internal class ProductCreator
    {
        public IDBRequestSystem db { get; set; }
        public Product CreateProduct(Guid id, string name, string Manufacturer, bool InStock, decimal Price)
        {
            Product product = new Product(id, name, Price, Manufacturer, InStock);

            db.AddProduct(product);

            return product;
        }

        public void Demonstration()
        {
            CreateProduct(new Guid(), "Product 1", "IP ISHO", true, 25);
            CreateProduct(new Guid(), "Product 2", "ROGA I KOPITA", false, 31);
            CreateProduct(new Guid(), "Product 3", "Antonio Pripizduchi", true, 5);
        }
    }
}
