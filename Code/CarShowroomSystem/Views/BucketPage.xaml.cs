using CarShowroomSystem.ViewModels;

namespace CarShowroomSystem.Views;

public partial class BucketPage : ContentPage
{
    BucketViewModel vm;
    public BucketPage(BucketViewModel vm)
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