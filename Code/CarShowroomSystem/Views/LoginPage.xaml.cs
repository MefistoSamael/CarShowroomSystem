using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Messaging;
using CarShowroomSystem.ViewModels;

namespace CarShowroomSystem.Views;

public partial class LoginPage : ContentPage
{
    LoginViewModel vm = new LoginViewModel();
    public LoginPage()
    {
        BindingContext = vm;
        InitializeComponent();
    }
}