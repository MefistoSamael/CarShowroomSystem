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
        BMW_3_Series,
        Mercedes_Benz_C_Class,
        Audi_A4,
        Nissan_Altima,
        Jeep_Wrangler,
        Subaru_Outback,
        Hyundai_Sonata,
        Kia_Optima,
        Porsche_911,
        Tesla_Model_S,
        Volkswagen_Golf,
        Ford_F_150,
        Chevrolet_Silverado,
        Dodge_Charger,
        GMC_Sierra,
        Toyota_Camry,
        Honda_Accord,
        Jeep_Grand_Cherokee,
        Subaru_Forester,
        BMW_5_Series,
        Mercedes_Benz_E_Class,
        Audi_Q5,
        Nissan_Rogue,
        Hyundai_Tucson,
        Kia_Sportage,
        Porsche_Cayenne
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

    public enum CarColor
    {
        Red,
        Blue,
        Green,
        Yellow,
        Orange,
        Purple,
        Pink,
        Brown,
        Black,
        White,
        Gray,
    }

    public enum WheelDriveType
    {
        Front_Wheel_Drive,
        Rear_Wheel_Drive,
        All_Wheel_Drive_AWD,
    }

    public class Car : Product
    {
        public CarModel Model { get; set; }

        public EngineType Engine { get; set; }

        public GearboxType Gearbox { get; set; }

        public float FuelTankCapacity { get; set; }

        public DateTime ManufactureDate { get; set; }

        public CarColor Color { get; set; }

        public WheelDriveType WheelDrive { get; set; }

        public float Power { get; set; }

        public float FuelConsumption { get; set; }

        //public Car(CarModel model, EngineType engine, GearboxType gearbox, float fuelTankCapacity, DateTime manufactureDate, CarColor color, WheelDriveType wheelDrive, float weight, float power, float torque, float fuelConsumptionCity, float fuelConsumptionHighway, Guid id, string name, decimal price, string manufacturer, bool inStock) : base(id, name, price, manufacturer, inStock)
        //{
        //    Model = model;
        //    Engine = engine;
        //    Gearbox = gearbox;
        //    FuelTankCapacity = fuelTankCapacity;
        //    ManufactureDate = manufactureDate;
        //    Color = color;
        //    WheelDrive = wheelDrive;
        //    Weight = weight;
        //    Power = power;
        //    Torque = torque;
        //    FuelConsumptionCity = fuelConsumptionCity;
        //    FuelConsumptionHighway = fuelConsumptionHighway;
        //}
    }
}
