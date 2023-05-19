using CarShowroomSystem.Entities.Users;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShowroomSystem.Model;

namespace CarShowroomSystem.ViewModels
{
    [ObservableObject]
    public partial class MainViewModel : IQueryAttributable
    {

        [ObservableProperty] bool show_Profile_Button = true;
        private IUser currentUser;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            currentUser = query["User"] as IUser;
        }

        [RelayCommand]
        private async void Exit()
        {
            await Shell.Current.GoToAsync("//login", false);
        }
    }
}
