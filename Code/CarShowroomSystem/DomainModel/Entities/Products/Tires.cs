using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomSystem.Entities.Products
{
    public enum SeasonType
    {
        Spring,
        Summer,
        Autumn,
        Winter,
        Rainy,
        Dry
    }

    public enum ConstructionType
    {
        Bias,
        Tubeless,
        Tube_type,
        Run_Flat,
        All_Season,
    }

    public class Tires : Product
    {
        public SeasonType Season { get; set; }

        public float Width { get; set; }

        public float ProfileHeight { get; set; }

        public ConstructionType ConstructionType { get; set; }

        public float RimDiameter { get; set; }

        public float LoadIndex { get; set; }

        public char SpeedIndex { get; set; }

    }

}
