using CarShowroomSystem.ViewModels.User;

namespace CarShowroomSystem.Views.User;

public partial class ChangeUserPage : ContentPage
{
	public ChangeUserPage(ChangeUserViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}