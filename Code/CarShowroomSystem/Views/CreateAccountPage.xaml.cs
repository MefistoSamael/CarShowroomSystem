namespace CarShowroomSystem.Views;

public partial class CreateAccountPage : ContentPage
{
	public CreateAccountPage()
	{
		InitializeComponent();
		var s = new BackButtonBehavior();
		s.IsVisible = false;
		Shell.SetBackButtonBehavior(Shell.Current,s);
	}
}