
using CarShowroomSystem.ViewModels.Car;


namespace CarShowroomSystem.Views.Car;

public partial class AddCarPage : ContentPage
{
	public AddCarPage(AddCarViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();

		// добавл€ем обработчик выбора типа двигател€
        enginePicker.SelectedIndexChanged += vm.HandleSelectedIndexChangedEngine;
		gearboxPicker.SelectedIndexChanged += vm.HandleSelectedIndexChangedGearBox;
		wheelDrivePicker.SelectedIndexChanged += vm.HandleSelectedIndexChangedWheelDrive;
		datePicker.DateSelected += vm.HandleSelectedIndexChangedDateTime;
		checkBox.CheckedChanged += vm.HandleCheckedChanged;
    }

}