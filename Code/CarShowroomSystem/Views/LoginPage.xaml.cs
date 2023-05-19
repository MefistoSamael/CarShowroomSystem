using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Messaging;
using CarShowroomSystem.ViewModels;
using System.Xml.Linq;
using CarShowroomSystem.Model;

namespace CarShowroomSystem.Views;

public partial class LoginPage : ContentPage
{
    LoginViewModel vm;
    // конструктор, используемый при переходе со страницы
    public LoginPage(LoginViewModel vm)
    {
        this.vm = vm;

        BindingContext = this.vm;
        InitializeComponent();
    }

}