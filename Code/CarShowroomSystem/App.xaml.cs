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


    protected override Window CreateWindow(IActivationState activationState)
    {
        var windows = base.CreateWindow(activationState);

        windows.Width = 600;
        windows.Height = 600;

        return windows;
    }
}
