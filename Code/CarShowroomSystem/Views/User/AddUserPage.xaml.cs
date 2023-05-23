using CarShowroomSystem.ViewModels.User;

namespace CarShowroomSystem.Views.User;

public partial class AddUserPage : ContentPage
{
	public AddUserPage(AddUserViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();

		rolePicker.SelectedIndexChanged += vm.HandleSelectedIndexChangedRole;

    }
}