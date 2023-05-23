using CarShowroomSystem.ViewModels.User;

namespace CarShowroomSystem.Views.User;

public partial class ViewUserPage : ContentPage
{
	public ViewUserPage(ViewUserViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}