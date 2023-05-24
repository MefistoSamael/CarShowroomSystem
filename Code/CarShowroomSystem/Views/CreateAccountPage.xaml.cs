
using CarShowroomSystem.Model;
using CarShowroomSystem.ViewModels;

namespace CarShowroomSystem.Views;

public partial class CreateAccountPage : ContentPage
{
	public CreateAccountPage(CreateAccountViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
		}

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}