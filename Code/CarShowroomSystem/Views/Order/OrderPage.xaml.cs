using CarShowroomSystem.ViewModels;
using CarShowroomSystem.ViewModels.Order;

namespace CarShowroomSystem.Views.Order;

public partial class OrderPage : ContentPage
{
	OrderViewModel vm;
    public OrderPage(OrderViewModel vm)
	{
		this.vm = vm;
		BindingContext = vm;
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		vm.RefrechObservableCollection();
    }
}