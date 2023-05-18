using CarShowroomSystem.Views;

namespace CarShowroomSystem;

public partial class AppShell : Shell
{
	public AppShell()
	{

        Routing.RegisterRoute("loginpage", typeof(LoginPage));
        Routing.RegisterRoute("createaccount", typeof(CreateAccountPage));
        //Routing.RegisterRoute("mainpage", typeof(MainPage));

        InitializeComponent();
	}
}
