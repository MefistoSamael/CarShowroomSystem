using CarShowroomSystem.Entities.Products;
using CarShowroomSystem.Model;
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
    public partial class AddCarViewModel
    {
        // модель для работы с бизнес логикой
        IModel bm;
        // вводимая переменная
        [ObservableProperty] private string model = "";
        // сообщение, выводимое при ошибке
        [ObservableProperty] private string modelErrorMessage;
        // переменная отвечающая за вывод лейбла ошибкм
        [ObservableProperty] private bool showModelErrorMessage;
        [ObservableProperty] private bool validModel;


        // для всех остальных штук АНАЛогично

        [ObservableProperty] private string name = "";
        [ObservableProperty] private string nameErrorMessage;
        [ObservableProperty] private bool validName;
        [ObservableProperty] private bool showNameErrorMessage;

        [ObservableProperty] private string manufacturer = "";
        [ObservableProperty] private string manufacturerErrorMessage;
        [ObservableProperty] private bool showManufacturerErrorMessage;
        [ObservableProperty] private bool validManufacturer;

        [ObservableProperty] private string photoPath = "";
        [ObservableProperty] private string photoPathErrorMessage;
        [ObservableProperty] private bool showPhotoPathErrorMessage;
        [ObservableProperty] private bool validPhotoPath;

        [ObservableProperty] private string myColor = "";
        [ObservableProperty] private string myColorErrorMessage;
        [ObservableProperty] private bool showMyColorErrorMessage;
        [ObservableProperty] private bool validMyColor;

        [ObservableProperty] private string power = "";
        [ObservableProperty] private string powerErrorMessage;
        [ObservableProperty] private bool showPowerErrorMessage;
        [ObservableProperty] private bool validPower;


        [ObservableProperty] private string fuelConsumption = "";
        [ObservableProperty] private string fuelConsumptionErrorMessage;
        [ObservableProperty] private bool showFuelConsumptionErrorMessage;
        [ObservableProperty] private bool validFuelConsumption;

        [ObservableProperty] private string fuelTankCapacity = "";
        [ObservableProperty] private string fuelTankCapacityErrorMessage;
        [ObservableProperty] private bool showFuelTankCapacityErrorMessage;
        [ObservableProperty] private bool validFuelTankCapacity;


        [ObservableProperty] private string price = "";
        [ObservableProperty] private string priceErrorMessage;
        [ObservableProperty] private bool showPriceErrorMessage;
        [ObservableProperty] private bool validPrice;

        private EngineType engineType;
        [ObservableProperty] private string engineTypeErrorMessage = "*Chose Engine type";
        [ObservableProperty] private bool showEngineTypeErrorMessage = true;
        [ObservableProperty] private bool validEngineType;

        private GearboxType gearboxType;
        [ObservableProperty] private string geraboxTypeErrorMessage = "*Chose Gearbox Type";
        [ObservableProperty] private bool showGeraboxTypeErrorMessage = true;
        [ObservableProperty] private bool validGearboxType;

        private WheelDriveType wheelDriveType;
        [ObservableProperty] private string wheelDriveTypeErrorMessage = "*Chose WheelDrive Type";
        [ObservableProperty] private bool showWheelDriveTypeErrorMessage = true;
        [ObservableProperty] private bool validWheelDriveType;


        private DateTime manufactuMediumPurpleate = new DateTime(1990,12,1);

        [ObservableProperty] private bool inStock = true;

        // переменная отвечающая за возможность нажатия на кнопку создания машины
        // если все поля введены и корректны - она true, иначе false
        // некорректные данные - ввели буквы в поле Price
        [ObservableProperty] private bool enableButton = false;





        // проверка ввода модели
        // для всех остальных методов Validate та же логика
        [RelayCommand]
        public Task ValidateModel()
        {
            // если модель ввели
            if (!string.IsNullOrEmpty(Model))
            {
                // не показываем лейбл с ошибкой
                ShowModelErrorMessage = false;
                ValidModel = true;
            }
            else
            {
                // устанавливаем текст ошибка
                ModelErrorMessage = "*Please enter a model";
                // выводим лейбл
                ShowModelErrorMessage = true;
                ValidModel = false;
            }

            // устанавливаем поле, отвечающее за работоспособность кнопки
            UpdateEnableButton();
            return Task.CompletedTask;
        }

        [RelayCommand]
        public Task ValidateName()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                ShowNameErrorMessage = false;
                ValidName = true;
            }
            else
            {
                NameErrorMessage = "*Please enter a name";
                ShowNameErrorMessage = true;
                ValidName = false;
            }

            UpdateEnableButton();
            return Task.CompletedTask;
        }

        [RelayCommand]
        public Task ValidateManufacturer()
        {
            if (!string.IsNullOrEmpty(Manufacturer))
            {
                ShowManufacturerErrorMessage = false;
                ValidManufacturer = true;
            }
            else
            {
                ManufacturerErrorMessage = "*Please enter a manufacturer";
                ShowManufacturerErrorMessage = true;
                ValidManufacturer = false;
            }

            UpdateEnableButton();
            return Task.CompletedTask;
        }

        [RelayCommand]
        public Task ValidatePhotoPath()
        {
            if (!string.IsNullOrEmpty(PhotoPath))
            {
                ShowPhotoPathErrorMessage = false;
                ValidPhotoPath = true;
            }
            else
            {
                PhotoPathErrorMessage = "*Please enter a photo path";
                ShowPhotoPathErrorMessage = true;
                ValidPhotoPath = false;
            }

            UpdateEnableButton();
            return Task.CompletedTask;
        }

        [RelayCommand]
        public Task ValidateColor()
        {
            if (!string.IsNullOrEmpty(MyColor))
            {
                ShowMyColorErrorMessage = false;
                ValidMyColor = true;
            }
            else
            {
                MyColorErrorMessage = "*Please enter a color";
                ShowMyColorErrorMessage = true;
                ValidMyColor = false;
            }

            UpdateEnableButton();
            return Task.CompletedTask;
        }

        [RelayCommand]
        public Task ValidatePower()
        {
            if (!string.IsNullOrEmpty(Power) && IsDigit(Power))
            {
                ShowPowerErrorMessage = false;
                ValidPower = true;
            }
            else
            {
                PowerErrorMessage = "*Please enter a valid power value";
                ShowPowerErrorMessage = true;
                ValidPower = false;
            }

            UpdateEnableButton();
            return Task.CompletedTask;
        }

        

        [RelayCommand]
        public Task ValidateFuelConsumption()
        {
            if (!string.IsNullOrEmpty(FuelConsumption) && IsDigit(FuelConsumption))
            {
                ShowFuelConsumptionErrorMessage = false;
                ValidFuelConsumption = true;
            }
            else
            {
                FuelConsumptionErrorMessage = "*Please enter a valid fuel consumption value";
                ShowFuelConsumptionErrorMessage = true;
                ValidFuelConsumption = false;
            }

            UpdateEnableButton();
            return Task.CompletedTask;
        }

        [RelayCommand]
        public Task ValidateFuelTankCapacity()
        {
            if (!string.IsNullOrEmpty(FuelTankCapacity) && IsDigit(FuelTankCapacity))
            {
                ShowFuelTankCapacityErrorMessage = false;
                ValidFuelTankCapacity = true;
            }
            else
            {
                FuelTankCapacityErrorMessage = "*Please enter a valid fuel tank capacity value";
                ShowFuelTankCapacityErrorMessage = true;
                ValidFuelTankCapacity = false;
            }

            UpdateEnableButton();
            return Task.CompletedTask;
        }

        // проверка ввода цены
        [RelayCommand]
        public Task ValidatePrice()
        {
            if (!string.IsNullOrEmpty(Price) && IsDigit(Price))
            {
                ShowPriceErrorMessage = false;
                ValidPrice = true;
            }
            else
            {
                PriceErrorMessage = "*Please enter a valid price";
                ShowPriceErrorMessage = true;
                ValidPrice = false;
            }

            UpdateEnableButton();
            return Task.CompletedTask;
        }

        public AddCarViewModel(IModel model) 
        {
            this.bm = model;
        }

        //устанавливает engineType при выборе элемента в Picker
        public void HandleSelectedIndexChangedEngine(object sender, EventArgs e)
        {
            var picker = sender as Picker;

            engineType = (EngineType)picker.SelectedIndex;
            ShowEngineTypeErrorMessage = false;
            ValidEngineType = true;
            UpdateEnableButton();
        }

        // устанавливает gearboxType при выборе элемента в Picker
        public void HandleSelectedIndexChangedGearBox(object sender, EventArgs e)
        {
            var picker = sender as Picker;

            gearboxType = (GearboxType)picker.SelectedIndex;
            ShowGeraboxTypeErrorMessage = false;
            ValidGearboxType = true;
            UpdateEnableButton();
        }

        //устанавливает wheelDriveType при выборе элемента в Picker
        public void HandleSelectedIndexChangedWheelDrive(object sender, EventArgs e)
        {
            var picker = sender as Picker;

            wheelDriveType = (WheelDriveType)picker.SelectedIndex;
            ShowWheelDriveTypeErrorMessage = false;
            ValidWheelDriveType = true;
            UpdateEnableButton();
        }

        //устанавливает manufactuMediumPurpleate при выборе даты
        public void HandleSelectedIndexChangedDateTime(object sender, EventArgs e)
        {
            var picker = sender as DatePicker;

            manufactuMediumPurpleate = picker.Date;
            UpdateEnableButton();
        
        }

        public void HandleCheckedChanged(object sender, EventArgs e)
        {
            var checker = sender as CheckBox;

            InStock = checker.IsChecked;
        }

        //обновляет enableButton в соответствии с введенными данными
        private void UpdateEnableButton()
        {
            EnableButton = ValidModel &&
                ValidMyColor &&
                ValidName &&
                ValidPhotoPath &&
                ValidPower &&
                ValidPrice &&
                ValidWheelDriveType &&
                ValidEngineType &&
                ValidGearboxType &&
                ValidManufacturer &&
                ValidEngineType &&
                ValidFuelTankCapacity &&
                ValidFuelConsumption;
        }

        // проверяет на то, является ли переданная строка числом
        private bool IsDigit(string value)
        {
            try
            {
                Convert.ToDecimal(value);
            }
            catch
            {
                return false;
            }
            return true;
        }

        [RelayCommand]
        private async void CreateCar()
        {
            bm.CreateCar(Model, engineType, gearboxType, (float)Convert.ToDouble(FuelTankCapacity), manufactuMediumPurpleate, MyColor, wheelDriveType, (float)Convert.ToDouble(Power), (float)Convert.ToDouble(FuelConsumption), Name, Convert.ToDecimal(Price), Manufacturer, InStock, PhotoPath);
            await Shell.Current.GoToAsync("..");
        }
    }


}
