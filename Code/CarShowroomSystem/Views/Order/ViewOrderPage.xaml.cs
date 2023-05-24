using CarShowroomSystem.ViewModels.Order;

namespace CarShowroomSystem.Views.Order;

public partial class ViewOrderPage : ContentPage
{
	ViewOrderViewModel vm;
	public ViewOrderPage(ViewOrderViewModel vm)
	{
		this.vm = vm;
		BindingContext = vm;
		InitializeComponent();
	}

}