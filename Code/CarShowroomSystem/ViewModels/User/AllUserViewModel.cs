using CarShowroomSystem.Entities.Users;
using CarShowroomSystem.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomSystem.ViewModels.User
{
    [ObservableObject]
    public partial class AllUserViewModel : IQueryAttributable
    {
        // модель, для вызова методов предметной области
        private IModel model;

        private string currentUserLogin;

        // пользователи, отображаемые на странциу
        public ObservableCollection<IUser> Users { get; set; }

        // выбранный пользователь
        IUser selectedUser;

        public AllUserViewModel(IModel model)
        {
            this.model = model;
            Users = new ObservableCollection<IUser>(model.GetAllUsers());
        }

        // нажатие на кнопку с напдписью Exit
        [RelayCommand]
        private async void Exit()
        {
            model.LogOut();
            //возвращает на страницу входа в аккаунт
            await Shell.Current.GoToAsync("//login", false);
        }

        [RelayCommand]
        private async void AddUser()
        {
            // словарь нужен для работы костыльного обновления ObservableCollection пользователей
            await Shell.Current.GoToAsync("adduserpage", new Dictionary<string, object>() { { "h",1} });
        }


            [RelayCommand]
        private async void ChangeUser()
        {
            if (selectedUser == null)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("No Selection", $"You need to select, which item to delete", "ok");
            }
            else if (selectedUser.Login == model.GetCurrentUser().Login)
                await Shell.Current.DisplayAlert("Error", "You cant change login of current user", "ok");
            else
            {
                var navigationParameter = new Dictionary<string, object>() { { "selectedUser", selectedUser } };
                await Shell.Current.GoToAsync("changeuserpage", navigationParameter);
            }

        }
        // вызывает страницу, на которой отображается 
        // подробная информация о пользователе
        [RelayCommand]
        private async void ViewUser()
        {
            if (selectedUser == null)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("No Selection", $"You need to select, which item to show", "ok");
            }
            else
            {
                var navigationParameter = new Dictionary<string, object>() { { "selectedUser", selectedUser } };
                await Shell.Current.GoToAsync("viewuserpage", navigationParameter);
            }
        }


        // удаляет пользователя. ЧТобы удалить пользоватлея надо его выбрать
        [RelayCommand]
        private async void DeleteUser()
        {
            // проверко на то, что выбранный пользователь не null
            if (selectedUser == null)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("No Selection", $"You need to select, which item to delete", "ok");
            }
            else if (selectedUser.Login == model.GetCurrentUser().Login)
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Error", $"You cant delete your account", "ok");
            else
            {
                // удаляем пользователя из бд
                model.DeleteUser(selectedUser.Login);


                RefrechObservableCollection();

            }

        }


        // обраюотка изменения выбранного элемента в CollectionView
        // просто запихуивает выбранного пользователя в поле selectedUser
        // оно нужно для действий по добавлению и удалению пользователя
        //
        // почему я не сделал вызова свойств SelectedItem у CollectionView на прямую?
        // потому что я не знаю как его получить из кода ViewModel по-другому
        [RelayCommand]
        private void HandleSelectionChanged(object SelectedItem)
        {
            selectedUser = SelectedItem as IUser;
        }

        // обновляет коллекцию всех пользователей
        private async void RefrechObservableCollection()
        {
            // получаем всех пользователей в бд
            var users = model.GetAllUsers();

            //чистим ObservableCollection
            Users.Clear();
            // переносим всех пользщователей из списка из БД в
            // ObservableCollection 
            foreach (var user in users)
            {

                await Task.Run(() => Thread.Sleep(100));
                Users.Add(user);
            }

        }

        // костыль чтобы список пользователей обновлялся
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            RefrechObservableCollection();
        }
    }
}
