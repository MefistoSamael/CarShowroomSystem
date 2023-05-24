using CarShowroomSystem.Views;
using CarShowroomSystem.Views.User;
using CarShowroomSystem.Views.Car;
using CarShowroomSystem.Views.Order;

namespace CarShowroomSystem;

public partial class AppShell : Shell
{
	public AppShell()
	{

        Routing.RegisterRoute("loginpage", typeof(LoginPage));
        Routing.RegisterRoute("createaccount", typeof(CreateAccountPage));
        Routing.RegisterRoute("mainpage", typeof(MainPage));
        Routing.RegisterRoute("addcarpage", typeof(AddCarPage));
        Routing.RegisterRoute("changecarpage", typeof(ChangeCarPage));
        Routing.RegisterRoute("viewcarpage", typeof(ViewCarPage));
        Routing.RegisterRoute("adduserpage", typeof(AddUserPage));
        Routing.RegisterRoute("changeuserpage", typeof(ChangeUserPage));
        Routing.RegisterRoute("viewuserpage", typeof(ViewUserPage));
        Routing.RegisterRoute("alluserpage", typeof(AllUserPage));
        Routing.RegisterRoute("bucketpage", typeof(BucketPage));
        Routing.RegisterRoute("orderpage", typeof(OrderPage));
        Routing.RegisterRoute("vieworderpage", typeof(ViewOrderPage));

        InitializeComponent();
	}
}
