using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Messaging;
using CarShowroomSystem.ViewModels;
using System.Xml.Linq;
using CarShowroomSystem.Model;

namespace CarShowroomSystem.Views;

public partial class LoginPage : ContentPage
{
    // поскольку dependecy injection не работает, дом труба его шатал,
    // нужны два конструктора: один на первоначальное создание страницы(при запуске программы будет вызвана
    // именна это страница с этим конструктором), второй - если на страницу перейдут из другой страницы(чел
    // вошел в аккаунт и решил выйти)


    LoginViewModel vm;
    // конструктор, используемый при переходе со страницы
    public LoginPage(LoginViewModel vm)
    {
        this.vm = vm;

        BindingContext = vm;
        InitializeComponent();
    }

    //шоб работало Application.Current.MainPage = new AppShell();
    public LoginPage()
    {

    }
}