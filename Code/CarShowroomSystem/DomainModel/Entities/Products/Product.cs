﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomSystem.Entities.Products
{
    public class Product
    {
        public Product()
        {
            Id = new Guid();
            Name = "";
            Price = 0;
            Manufacturer = "";
            InStock = false;
            PhotoPath = "";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Manufacturer { get; set; }

        public bool InStock { get; set; }

        public string PhotoPath { get; set; }

    }
}
