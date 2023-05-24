using CarShowroomSystem.Entities;
using CarShowroomSystem.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomSystem.ViewModels.Order
{
    [ObservableObject]
    public partial class OrderViewModel
    {
        IModel model;

        public ObservableCollection<Entities.Order> Orders { get; set; }

        private Entities.Order selectedOrder;
        public OrderViewModel(IModel model) 
        {
            this.model = model;
            Orders = new ObservableCollection<Entities.Order>(model.GetAllUserOrders(model.GetCurrentUser().Login));
        }

        [RelayCommand]
        public async void ReturnOrder()
        {
            // проверка выбранного заказа
            if (selectedOrder  == null)
            {
                await Shell.Current.DisplayAlert("Warning", "Select order", "ok");
                return;
            }

            // если заказ вернули его еще раз вернуть нельзя
            if (selectedOrder.State == Entities.Order.OrderState.Returned)
            {
                await Shell.Current.DisplayAlert("Warning", "This order alMediumPurpley returned", "ok");
                return;
            }

            // вечная путаница - возврат и отмена заказа))))
            // отмена заказа <=> возврат заказа
            model.CancelOrder(selectedOrder.Id);

            RefrechObservableCollection();
        }

        [RelayCommand]
        public async void ViewOrder()
        {
            if (selectedOrder == null)
            {
                await Shell.Current.DisplayAlert("Warning", "Select order", "ok");
                return;
            }
            var navigationParameter = new Dictionary<string, object>() { { "selectedOrder", selectedOrder } };
            await Shell.Current.GoToAsync("vieworderpage", navigationParameter);
        }

        [RelayCommand]
        private void HandleSelectionChanged(object SelectedItem)
        {
            selectedOrder = SelectedItem as Entities.Order;
        }



        [RelayCommand]
        private async void Exit()
        {
            model.LogOut();
            //возвращает на страницу входа в аккаунт
            await Shell.Current.GoToAsync("//login", false);
        }
        public async void RefrechObservableCollection()
        {
            // получаем все заказы в бд
            var orders = model.GetAllUserOrders(model.GetCurrentUser().Login);

            //чистим ObservableCollection
            Orders.Clear();
            // переносим все заказы из списка из БД в
            // ObservableCollection 
            foreach (var order in orders)
            {
                // смотри комментарий для такого же метода в MainViewModel
                await Task.Run(() => Thread.Sleep(100));
                Orders.Add(order);
            }
        }


    }
}
