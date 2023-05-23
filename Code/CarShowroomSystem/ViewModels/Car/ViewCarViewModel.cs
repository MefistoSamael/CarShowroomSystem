
using CarShowroomSystem.Entities.Products;
using CarShowroomSystem.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarShowroomSystem.ViewModels.Car
{
    [ObservableObject]
    public partial class ViewCarViewModel : IQueryAttributable
    {
        // вводимая переменная
        [ObservableProperty] private string model = null;

        [ObservableProperty] private string name = null;

        [ObservableProperty] private string manufacturer = null;

        [ObservableProperty] private string photoPath = null;

        [ObservableProperty] private string myColor = null;

        [ObservableProperty] private string power = null;

        [ObservableProperty] private string fuelConsumption = null;

        [ObservableProperty] private string fuelTankCapacity = null;

        [ObservableProperty] private string price = null;

        [ObservableProperty] private string engine = null;

        [ObservableProperty] private string gearbox = null;

        [ObservableProperty] private string wheelDrive = null;

        [ObservableProperty] private string manufactureDate = null;

        [ObservableProperty] private string isInStock = null;

        IModel bm;

        Entities.Products.Car selectedCar;
         
        public ViewCarViewModel(IModel bm)
        {
            this.bm = bm;
        }

        //чтобы получать заначения из при переходе из других страниц
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            // получаем машину из переданного словаря 
            selectedCar = query["Car"] as Entities.Products.Car;

            //устанавливаем свойства для отображения
            Model = selectedCar.Model;
            Name = selectedCar.Name;
            Manufacturer = selectedCar.Manufacturer;
            PhotoPath = selectedCar.PhotoPath;
            MyColor = selectedCar.Color;
            Power = selectedCar.Power.ToString();
            FuelConsumption = selectedCar.FuelConsumption.ToString();
            FuelTankCapacity = selectedCar.FuelTankCapacity.ToString();
            Price = selectedCar.Price.ToString();
            Engine = selectedCar.Engine.ToString();
            Gearbox = selectedCar.Gearbox.ToString();
            WheelDrive = selectedCar.WheelDrive.ToString();
            ManufactureDate = selectedCar.ManufactureDate.ToString();
            IsInStock = selectedCar.InStock.ToString();
        }

    }
}
