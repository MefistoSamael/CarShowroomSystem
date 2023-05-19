using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShowroomSystem.Model;
using CarShowroomSystem.Views;

namespace CarShowroomSystem.ViewModels
{
    [ObservableObject]
    public partial class CreateAccountViewModel
    {

        //[ObservableProperty] bool showExitButton = false;
        [ObservableProperty] private string name;
        [ObservableProperty] private string fullName;
        [ObservableProperty] private string password;
        [ObservableProperty] private string nameErrorMessage;
        [ObservableProperty] private string fullNameErrorMessage;
        [ObservableProperty] private string passwordErrorMessage;
        [ObservableProperty] private bool showNameErrorMessage;
        [ObservableProperty] private bool showFullNameErrorMessage;
        [ObservableProperty] private bool showPasswordErrorMessage;
        [ObservableProperty] private bool enableButton;
        [ObservableProperty] private bool isValidName;
        [ObservableProperty] private bool isValidFullName;
        [ObservableProperty] private bool isValidPassword;
        IModel model;

        public CreateAccountViewModel(IModel model)
        {
            this.model = model;
        }

        [RelayCommand]
        private async void SignUp()
        {
            var user = model.AddUser(Name, Password, Roles.customer, FullName);

            if (user == null) 
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Error",
            "Can not create user with such user name", "Ok");
            }
            else
            {
                var navigationParameter = new Dictionary<string, object>() { { "User", user } };
                await Shell.Current.GoToAsync($"//main", false, navigationParameter);
            }
        }

        [RelayCommand]
        public Task ValidateName()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                IsValidName = true;
                ShowNameErrorMessage = false;
                EnableButton = IsValidName && IsValidFullName && IsValidPassword;
            }
            else
            {
                NameErrorMessage = "*Please enter a name with at least one characters";
                IsValidName = false;
                ShowNameErrorMessage = true;
                EnableButton = IsValidName && IsValidFullName && IsValidPassword;
            }

            return Task.CompletedTask;
        }

        [RelayCommand]
        public Task ValidateFullName()
        {
            if (!string.IsNullOrEmpty(FullName))
            {
                IsValidFullName = true;
                ShowFullNameErrorMessage = false;
                EnableButton = IsValidName && IsValidFullName && IsValidPassword;
            }
            else
            {
                FullNameErrorMessage = "*Please enter a full name with at least one characters";
                IsValidFullName = false;
                ShowFullNameErrorMessage = true;
                EnableButton = IsValidName && IsValidFullName && IsValidPassword;
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
                EnableButton = IsValidName && IsValidFullName && IsValidPassword;

            }
            else
            {
                PasswordErrorMessage = "*Invalid password. Must be at least 1 character";
                IsValidPassword = false;
                ShowPasswordErrorMessage = true;
                EnableButton = IsValidName && IsValidFullName && IsValidPassword;

            }

            return Task.CompletedTask;
        }

    }
}
