using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities.Products
{
    enum engineType
    {
        diesel = 1,
        petrol = 2,
        gas = 3,
    }
    internal class EngineOil : Product
    {
        public EngineOil() : base()
        {
            Composition = "";
            Viscosity = "";
            EngineType = new engineType();
            Volume = 0;
        }
        public EngineOil(string Composition, string Viscosity, engineType EngineType, float Volume, Guid id, string name, decimal price, string manufacturer, bool inStock) : base(id, name, price, manufacturer, inStock)
        {
            this.Composition = Composition;
            this.Viscosity = Viscosity;
            this.EngineType = EngineType;
            this.Volume = Volume;
        }

        public string Composition { get; set; }

        public string Viscosity { get; set; }

        public engineType EngineType { get; set; }

        public float Volume { get; set; }
    }
}
