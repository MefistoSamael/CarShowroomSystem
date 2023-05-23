using CarShowroomSystem.Entities.Users;
using CarShowroomSystem.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarShowroomSystem.ViewModels;

[ObservableObject]
public partial class LoginViewModel
{
    [ObservableProperty] private string logIn = "";
    [ObservableProperty] private string password = "";

    [ObservableProperty] private string logInErrorMessage;
    [ObservableProperty] private string passwordErrorMessage;
    [ObservableProperty] private bool showLogInErrorMessage;
    [ObservableProperty] private bool showPasswordErrorMessage;
    [ObservableProperty] private bool enableButton;
    [ObservableProperty] private bool isValidLogIn;
    [ObservableProperty] private bool isValidPassword;

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
            var navigationParameter = new Dictionary<string, object>() { { "User", user } };
            await Shell.Current.GoToAsync($"//main",navigationParameter);
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
        await Shell.Current.GoToAsync("adduserpage");
        //await Shell.Current.GoToAsync($"createaccount", false);
    }

    [RelayCommand]
    public Task ValidateLogIn()
    {
        if (!string.IsNullOrEmpty(LogIn))
        {
            IsValidLogIn = true;
            ShowLogInErrorMessage = false;
            EnableButton = IsValidLogIn && IsValidPassword;
        }
        else
        {
            LogInErrorMessage = "*Please enter a name with at least one characters";
            IsValidLogIn = false;
            ShowLogInErrorMessage = true;
            EnableButton = IsValidLogIn && IsValidPassword;
        }

        return Task.CompletedTask;
    }

    [RelayCommand]
    public Task ValidatePassword()
    {
        if (!string.IsNullOrEmpty(Password))
        {
            IsValidPassword = true;
            ShowPasswordErrorMessage = false;
            EnableButton = IsValidLogIn  && IsValidPassword;

        }
        else
        {
            PasswordErrorMessage = "*Invalid password. Must be at least 1 character";
            IsValidPassword = false;
            ShowPasswordErrorMessage = true;
            EnableButton = IsValidLogIn && IsValidPassword;

        }

        return Task.CompletedTask;
    }


}
