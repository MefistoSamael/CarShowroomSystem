using CarShowroomSystem.ViewModels;
using CarShowroomSystem.Views;

namespace CarShowroomSystem;

public partial class App : Microsoft.Maui.Controls.Application
{
	public App(LoginViewModel loginViewModel)
	{
		InitializeComponent();

		MainPage = new LoginPage(loginViewModel);
	}
}
