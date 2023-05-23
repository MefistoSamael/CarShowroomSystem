using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomSystem.Entities.Products
{
    public enum CarModel
    {
        Toyota_Corolla,
        Honda_Civic,
        Ford_Mustang,
        Chevrolet_Camaro,
    }

    public enum CarColor
    {
        Red,
        Blue,
        Green,
        Yellow,
    }

    public enum EngineType
    {
        Diesel_Engine,
        Gasoline_Engine,
        Electric_Motor,
        Hybrid_Engine,
    }

    public enum GearboxType
    {
        Manual_Transmission,
        Automatic_Transmission,
        SemiAutomatic_Transmission
    }



    public enum WheelDriveType
    {
        Front_Wheel_Drive,
        Rear_Wheel_Drive,
        All_Wheel_Drive_AWD,
    }

    public class Car : Product
    {
        public string Model { get; set; }


        public EngineType Engine { get; set; }

        public GearboxType Gearbox { get; set; }

        public float FuelTankCapacity { get; set; }

        public DateTime ManufactureDate { get; set; }

        public string Color { get; set; }


        public WheelDriveType WheelDrive { get; set; }

        public float Power { get; set; }

        public float FuelConsumption { get; set; }

    }
}
