using CarShowroomSystem.Entities.Users;
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
    public partial class ChangeUserViewModel : IQueryAttributable
    {
        [ObservableProperty] private string login;
        [ObservableProperty] private string password;
        [ObservableProperty] private string fullName;
        //[ObservableProperty] private Roles selectedRole;
        [ObservableProperty] private bool enableButton;

        private IUser selectedUser;
        private IModel bm;

        public ChangeUserViewModel(IModel model)
        {
            bm = model;
        }

        [RelayCommand]
        private async void ChangeUser()
        {
            if (bm.ChangeUserInfo(selectedUser.Login, Login, Password, FullName) == null)
                await Shell.Current.DisplayAlert("Error", "You cant change login to such new login", "ok");
            else
                // веселый словарь в аргументах нужен, чтобы вызвать метод
                // обновления ObservableCollection (через querry atribute)
                await Shell.Current.GoToAsync("..", new Dictionary<string, object>() { { "c", 1 } });
        }

        //public void HandleSelectedIndexChangedRole(object sender, EventArgs e)
        //{
        //    var picker = sender as Picker;

        //    SelectedRole = (Roles)picker.SelectedItem;
        //}

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            selectedUser = query["selectedUser"] as IUser;
        }
    }
}
