using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CarShowroomSystem.Views;
using CarShowroomSystem.Model;
using CarShowroomSystem.Entities.Users;

namespace CarShowroomSystem.ViewModels;

[ObservableObject]
public partial class LoginViewModel
{
    [ObservableProperty] private string logIn = "";
    [ObservableProperty] private string password = "";
    private IModel model;

    public LoginViewModel(IModel model)
    {
        this.model = model;
    }

    // кнопка вход
    [RelayCommand]
    private async Task Submit()
    {
        // проверка полей ввода
        // сделана булевая переменная, чтобы при неправильном вводе дальше не выполнялся метод
        if (!await CheckInput())
            return;

        // просим модель сделать вход
        IUser user = model.SignIn(LogIn, Password);
        // в случае успешного входа - оповещаем об этом и генерим новую страницу
        if (user != null) 
        {
            Microsoft.Maui.Controls.Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("mainpage");

            await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Submit", $"You entered as {LogIn}", "OK");
            // код перехода на новую страницу
        }
        // иначе - оповещаем пользователя о неудаче
        else
        {
            await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Invalid input", $"Wrong name or password", "((((");
        }
    }

    //проверка пользовательского логина и пароля
    // и в случае пустых полей - вывод сообщения
    private async Task<bool> CheckInput()
    {
        if (LogIn == "")
        {
            await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Ты че, пес?!", $"Извинись за пустое имя", "извини");
            return false;
        }
        else if (Password == "")
        {
            await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Ты че, пес?!", $"Извинись за пустой пароль", "извини");
            return false;
        }

        return true;
    }

    [RelayCommand]
    private async Task CreateAccount()
    {
        Microsoft.Maui.Controls.Application.Current.MainPage = new AppShell();

        await Shell.Current.GoToAsync($"createaccount");
    }
}
