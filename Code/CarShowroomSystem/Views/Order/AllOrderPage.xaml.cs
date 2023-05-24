using CarShowroomSystem.ViewModels.Order;

namespace CarShowroomSystem.Views.Order;

public partial class AllOrderPage : ContentPage
{
    AllOrderViewModel vm;

    public AllOrderPage(AllOrderViewModel vm)
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