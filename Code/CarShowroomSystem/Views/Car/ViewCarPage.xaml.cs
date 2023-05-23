using CarShowroomSystem.ViewModels.Car;

namespace CarShowroomSystem.Views.Car;

public partial class ViewCarPage : ContentPage
{
	public ViewCarPage(ViewCarViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}