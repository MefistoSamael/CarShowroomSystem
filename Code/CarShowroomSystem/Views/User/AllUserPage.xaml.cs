using CarShowroomSystem.ViewModels.User;

namespace CarShowroomSystem.Views.User;

public partial class AllUserPage : ContentPage
{
	public AllUserPage(AllUserViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}