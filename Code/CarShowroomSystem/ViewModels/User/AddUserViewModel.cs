using CarShowroomSystem.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomSystem.ViewModels.User
{
    [ObservableObject]
    public partial class AddUserViewModel
    {
        private IModel model;
        
        public AddUserViewModel(IModel model) 
        {
            this.model = model;
        }

        [ObservableProperty] private string login = string.Empty;
        [ObservableProperty] private string loginErrorMessage;
        [ObservableProperty] private bool showLoginErrorMessage;

        [ObservableProperty] private string password = string.Empty;
        [ObservableProperty] private string passwordErrorMessage;
        [ObservableProperty] private bool showPasswordErrorMessage;

        [ObservableProperty] private string fullName = string.Empty;
        [ObservableProperty] private string fullNameErrorMessage;
        [ObservableProperty] private bool showFullNameErrorMessage;

        [ObservableProperty] private Roles selectedRole = (Roles)(-1);
        [ObservableProperty] private string roleErrorMessage = "*Select a role";
        [ObservableProperty] private bool showRoleErrorMessage = true;

        [ObservableProperty] private bool enableButton;



        [RelayCommand]
        private void ValidateLogin()
        {
            if (!string.IsNullOrEmpty(Login))
            {
                ShowLoginErrorMessage = false;
            }
            else
            {
                LoginErrorMessage = "*Please enter a login";
                ShowLoginErrorMessage = true;
            }
            UpdateEnableButton();
        }

        [RelayCommand]
        private void ValidatePassword()
        {
            if (!string.IsNullOrEmpty(Password))
            {
                ShowPasswordErrorMessage = false;
            }
            else
            {
                PasswordErrorMessage = "*Please enter a password";
                ShowPasswordErrorMessage = true;
            }
            UpdateEnableButton();
        }

        [RelayCommand]
        private void ValidateFullName()
        {
            if (!string.IsNullOrEmpty(FullName))
            {
                ShowFullNameErrorMessage = false;
            }
            else
            {
                FullNameErrorMessage = "*Please enter a full name";
                ShowFullNameErrorMessage = true;
            }
            UpdateEnableButton();
        }

        [RelayCommand]
        private void ValidateRole()
        {

            if (SelectedRole != (Roles)(-1))
            {
                ShowRoleErrorMessage = false;
            }
            else
            {
                RoleErrorMessage = "*Please select a role";
                ShowRoleErrorMessage = true;
            }
            UpdateEnableButton();
        }

        private void UpdateEnableButton()
        {
            EnableButton = !ShowLoginErrorMessage &&
                          !ShowPasswordErrorMessage &&
                          !ShowFullNameErrorMessage &&
                          !ShowRoleErrorMessage;
        }

        public void HandleSelectedIndexChangedRole(object sender, EventArgs e)
        {
            var picker = sender as Picker;

            SelectedRole = (Roles)picker.SelectedIndex;
            ShowRoleErrorMessage = false;

            UpdateEnableButton();
        }

        [RelayCommand]
        private async void SaveUser()
        {
            if (model.AddUser(Login, Password, SelectedRole, FullName) == null)
                await Shell.Current.DisplayAlert("Error", "You cant create user with such username", "ok");
            else
            {
                var crutchNavigationParameter = new Dictionary<string, object>() {{"updateView", true }};
                await Shell.Current.GoToAsync($"//usermain", false, crutchNavigationParameter);
            }
        }

    }

}
