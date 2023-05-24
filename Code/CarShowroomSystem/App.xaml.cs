using CarShowroomSystem.ViewModels;
using CarShowroomSystem.Views;
using CarShowroomSystem.Views.Car;

namespace CarShowroomSystem;

public partial class App : Microsoft.Maui.Controls.Application
{
	public App(LoginViewModel loginViewModel)
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

}
