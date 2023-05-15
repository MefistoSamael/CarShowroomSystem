using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities.Products
{
    public class EngineOil : Product
    {
        public string Composition { get; set; }

        public string Viscosity { get; set; }

        public EngineType EngineType { get; set; }

        //public EngineOil(string composition, string viscosity, EngineType engineType, Guid id, string name, decimal price, string manufacturer, bool inStock) : base(id, name, price, manufacturer, inStock)
        //{
        //    Composition = composition;
        //    Viscosity = viscosity;
        //    EngineType = engineType;
        //}
    }
}
