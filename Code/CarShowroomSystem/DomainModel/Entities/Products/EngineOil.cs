using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomSystem.Entities.Products
{
    public class EngineOil : Product
    {
        public string Composition { get; set; }

        public string Viscosity { get; set; }

        public EngineType EngineType { get; set; }

    }
}
