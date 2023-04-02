using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    internal class Product
    {
        private Guid id;
        public Guid Id
        {
            get { return id; }

            set
            {
                if (id != value)
                    id = value;
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                    name = value;
            }
        }

        private decimal price;
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (price != value)
                    price = value;
            }
        }

        private string manufacturer;
        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                if (manufacturer != value)
                    manufacturer = value;
            }
        }

        private bool inStock;
        public bool InStock
        {
            get
            {
                return inStock;
            }
            set
            {
                if (inStock != value)
                    inStock = value;
            }
        }

    }
}
