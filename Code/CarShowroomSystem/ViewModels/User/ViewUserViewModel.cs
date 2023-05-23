using CarShowroomSystem.Entities.Users;
using CarShowroomSystem.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomSystem.ViewModels.User
{
    [ObservableObject]
    public partial class ViewUserViewModel : IQueryAttributable
    {
        [ObservableProperty] private string login = null;
        [ObservableProperty] private string password = null;
        [ObservableProperty] private string fullName = null;

        IUser selectedUser;
        IModel bm;

        public ViewUserViewModel(IModel bm)
        {
            this.bm = bm;
        }


        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            selectedUser = query["selectedUser"] as IUser;
            Login = selectedUser.Login;
            Password = selectedUser.Password;
            FullName = selectedUser.FullName;
        }
    }
}
