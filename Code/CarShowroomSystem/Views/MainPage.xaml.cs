using CarShowroomSystem.Model;
using CarShowroomSystem.ViewModels;

namespace CarShowroomSystem.Views;

public partial class MainPage : ContentPage
{

	public MainPage(MainViewModel vm) 
	{
        BindingContext = vm;
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}

