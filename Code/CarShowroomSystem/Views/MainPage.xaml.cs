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
}

