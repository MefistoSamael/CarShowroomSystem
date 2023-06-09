﻿using CarShowroomSystem.Entities.Users;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShowroomSystem.Model;
using CarShowroomSystem.Entities.Products;
using System.Collections.ObjectModel;
using CarShowroomSystem.Views.Car;
using CarShowroomSystem.ViewModels.Car;
using CarShowroomSystem.Views;

namespace CarShowroomSystem.ViewModels
{
    [ObservableObject]
    public partial class MainViewModel : IQueryAttributable
    {
        // нынешний пользователь.
        // - Зачем?
        // - хз
        private IUser currentUser;

        // модель, для вызова методов предметной области
        private IModel model;

        // товары, отображаемые на странциу
        public ObservableCollection<Product> Products { get; set; }

        // поле отвечающее за показ кнопок по работе с товаром
        // кнопки доступны только админу
        [ObservableProperty] bool isAdmin;

        // выбранный товар
        Product selectedProduct;

        public MainViewModel(IModel model) 
        {
            this.model = model;
            Products = new ObservableCollection<Product>(model.GetAllProducts());
        }

        //чтобы получать заначения из при переходе из других страниц
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            // получаем пользователя из переданного словаря 
            currentUser = query["User"] as IUser;
            // устанавливаем поле, отвечающее за отображение команд админа
            IsAdmin = currentUser.Role == Roles.admin;
        }

        // нажатие на кнопку с напдписью Exit
        [RelayCommand]
        private async void Exit()
        {
            //возвращает на страницу входа в аккаунт
            await Shell.Current.GoToAsync("//login", false);
        }

        // открывает страницу на которой пользователь сможет добавить товар
        [RelayCommand]
        private async void AddProduct()
        {
            await Shell.Current.GoToAsync("addcarpage");

            // короче, вот вся эта шняга нужна, чтобы нормально работало обновление ObservableCollection после 
            // изменения его эллемента

            // тут мы получаем страницу ChangeCarPage, чтобы потом с ней взаимодействовать
            var page = Shell.Current.Navigation.NavigationStack.LastOrDefault() as AddCarPage;

            if (page != null)
            {
                // тут происходит какая то многопоточная магия которую написал чат гпт

                var tcs = new TaskCompletionSource<object>();

                // Подписываемся на событие Disappearing второй страницы
                page.Disappearing += (s, args) =>
                {
                    tcs.SetResult(null);
                };

                // Ожидаем завершения закрытия второй страницы
                await tcs.Task;

                // самое интересное в этом методе)))))
                RefrechObservableCollection();
            }
        }

        // открывает страницу на которой пользователь сможет изменить конкретный товар
        [RelayCommand]
        private async void ChangeProduct()
        {
            if (selectedProduct == null)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("No Selection", $"You need to select, which item to delete", "ok");
            }
            else
            {
                if (selectedProduct is Entities.Products.Car)
                {
                    var navigationParameter = new Dictionary<string, object>() { { "Car", selectedProduct } };
                    await Shell.Current.GoToAsync("changecarpage", navigationParameter);

                    // короче, вот вся эта шняга нужна, чтобы нормально работало обновление ObservableCollection после 
                    // изменения его эллемента

                    // тут мы получаем страницу ChangeCarPage, чтобы потом с ней взаимодействовать
                    var page = Shell.Current.Navigation.NavigationStack.LastOrDefault() as ChangeCarPage;

                    if (page != null)
                    {
                        // тут происходит какая то многопоточная магия которую написал чат гпт

                        var tcs = new TaskCompletionSource<object>();

                        // Подписываемся на событие Disappearing второй страницы
                        page.Disappearing += (s, args) =>
                        {
                            tcs.SetResult(null);
                        };

                        // Ожидаем завершения закрытия второй страницы
                        await tcs.Task;

                        // самое интересное в этом методе)))))
                        RefrechObservableCollection();


                    }

                }

            }

        }

            // удаляет товар. ЧТобы удалить товар надо его выбрать
            [RelayCommand]
        private async void DeleteProduct()
        {
            // проверко на то, что выбранный товар не null
            if (selectedProduct == null)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("No Selection", $"You need to select, which item to delete", "ok");
            }
            else
            {
                // удаляем товар из бд
                model.DeleteProduct(selectedProduct.Id);

                
                RefrechObservableCollection();

            }

        }

        // вызывает страницу, на которой отображается 
        // подробная информация о товаре
        [RelayCommand]
        private async void ViewProduct()
        {
            if (selectedProduct == null)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("No Selection", $"You need to select, which item to delete", "ok");
            }
            else
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Ok", $"Ok", "ok");
        }

            // обраюотка изменения выбранного элемента в CollectionView
            // просто запихуивает выбранный товар в поле selectedProduct
            // оно нужно для действий по добавлению и удалению товара
            //
            // почему я не сделал вызова свойств SelectedItem у CollectionView на прямую?
            // потому что я не знаю как его получить из кода
            [RelayCommand]
        private void HandleSelectionChanged(object SelectedItem)
        {
            selectedProduct = SelectedItem as Product;
        }

        // обновляет коллекцию всех товаров
        private async void RefrechObservableCollection()
        {
            // получаем все товары в бд
            var products = model.GetAllProducts();

            //чистим ObservableCollection
            Products.Clear();
            // переносим все товары из списка из БД в
            // ObservableCollection 
            foreach (var product in products)
            {
                // у любого нормального человека может возникуть вопрос:
                // - а на..., то есть зачем оно надо?
                // а я отвечу:
                // - вообще не вкуриваю. Я сделал клац клац по клавиатуре
                // и оно заработало

                // Короче говоря, без этой штуки при вызове из метода ChangeProduct или AddProduct
                // ничего не обновляется((((
                // Больше скажу - если значение 100 замнеить на 50 оно тоже не об-
                // новляется)))0 
                // АСИНХРОННОЕ ПРОГРАММИРОВАНИЕ - ВО 👍
                await Task.Run(() => Thread.Sleep(100));
                Products.Add(product);
            }




        }
    }
}
