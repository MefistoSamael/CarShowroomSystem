using CarShowroomSystem.ViewModels.Car;

namespace CarShowroomSystem.Views.Car;

public partial class ChangeCarPage : ContentPage
{
	public ChangeCarPage(ChangeCarViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}