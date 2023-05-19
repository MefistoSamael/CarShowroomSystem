using CarShowroomSystem.ViewModels;

namespace CarShowroomSystem.Views;

public partial class MainPage : ContentPage
{

	public MainPage() 
	{
        BindingContext = new MainViewModel();
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}

