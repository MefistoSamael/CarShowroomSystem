
using CarShowroomSystem.Entities.Products;
using CarShowroomSystem.Entities.Users;
using CarShowroomSystem.Model;
using CarShowroomSystem.Views.Car;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomSystem.ViewModels.Car
{
    [ObservableObject]
    public partial class ChangeCarViewModel : IQueryAttributable
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

        private EngineType engineType = (EngineType)(-1);

        private GearboxType gearboxType = (GearboxType)(-1);

        private WheelDriveType wheelDriveType = (WheelDriveType)(-1);

        private DateTime manufactureDate;

        [ObservableProperty] private bool inStock = true;

        IModel bm;

        Entities.Products.Car selectedCar;

        //устанавливает engineType при выборе элемента в Picker
        public void HandleSelectedIndexChangedEngine(object sender, EventArgs e)
        {
            var picker = sender as Picker;

            engineType = (EngineType)picker.SelectedIndex;
        }

        // устанавливает gearboxType при выборе элемента в Picker
        public void HandleSelectedIndexChangedGearBox(object sender, EventArgs e)
        {
            var picker = sender as Picker;

            gearboxType = (GearboxType)picker.SelectedIndex;
        }

        //устанавливает wheelDriveType при выборе элемента в Picker
        public void HandleSelectedIndexChangedWheelDrive(object sender, EventArgs e)
        {
            var picker = sender as Picker;

            wheelDriveType = (WheelDriveType)picker.SelectedIndex;
        }

        //устанавливает manufactureDate при выборе даты
        public void HandleSelectedIndexChangedDateTime(object sender, EventArgs e)
        {
            var picker = sender as DatePicker;

            manufactureDate = picker.Date;
        }

        public void HandleCheckedChanged(object sender, EventArgs e)
        {
            var checker = sender as CheckBox;

            InStock = checker.IsChecked;
        }

        //чтобы получать заначения из при переходе из других страниц
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            // получаем машину из переданного словаря 
            selectedCar = query["Car"] as Entities.Products.Car;
        }

        public ChangeCarViewModel(IModel model)
        {
            bm = model;
        }

        [RelayCommand]
        private async void ChangeCar()
        {
            bm.ChangeCarInfo(
                Model,
                engineType,
                gearboxType,
                // тернарка проверяет равен ли FuelTankCapacity пустой строке или null
                // если нет - преобразует, иначе передает Null
                // надо, потому что от пустой строки нельзя произвести преобразование в численному
                // типу
                (FuelTankCapacity != null) && (FuelTankCapacity != "") ? (float)Convert.ToDouble(FuelTankCapacity) : null,  
                manufactureDate,
                MyColor,
                wheelDriveType,
                (Power != null) && (Power != "") ? (float)Convert.ToDouble(Power) : null, 
                (FuelConsumption != null) && (FuelConsumption != "") ? (float)Convert.ToDouble(FuelConsumption) : null,
                selectedCar.Id,
                Name,
                (Price != null) && (Price != "") ? Convert.ToDecimal(Price) : null, 
                Manufacturer,
                InStock,
                PhotoPath);

            await Shell.Current.GoToAsync("..");
        }
    }
}
