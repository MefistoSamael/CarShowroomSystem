using CarShowroomSystem.ViewModels;

namespace CarShowroomSystem.Views;

public partial class MainPage : ContentPage
{
    private MainViewModel vm = new MainViewModel();

	public MainPage() 
	{
        BindingContext = vm;
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}

