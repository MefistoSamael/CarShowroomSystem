using CarShowroomSystem.Entities.Products;
using CarShowroomSystem.Entities.Users;
using CarShowroomSystem.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomSystem.ViewModels
{
    [ObservableObject]
    public partial class BucketViewModel : IQueryAttributable
    {
        public ObservableCollection<BucketItem> Bucket { get; set; }

        Product selectedProduct;

        IModel model;
        public BucketViewModel(IModel model)
        {
            this.model = model;
            var list = DicToList(model.GetCurrentUser().Bucket);
            Bucket = new ObservableCollection<BucketItem>(list);
        }

        // я не знаю какой метод всегда будет вызваться при переходе на страницу через TabBar
        // времени читать про это нет, поэтому будет так. Этот метод будет кадый раз 
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            RefrechObservableCollection();
        }

        // метод преобразующий корзину, хранисую у пользователя как словарь, 
        // в список, от которого будет создаваться ObservableCollection
        public List<BucketItem> DicToList(Dictionary<Guid, int> dict)
        {
            var list = new List<BucketItem>();

            foreach (var item in dict)
            {
                list.Add(new BucketItem { Prod = model.GetProductById(item.Key), Count = item.Value });
            }

            return list;
        }

        [RelayCommand]
        private async void DeleteProduct()
        {
            if (selectedProduct != null)
            {
                model.DeleteProductInBucket(selectedProduct.Id);
                RefrechObservableCollection();
            }
            else
                await Shell.Current.DisplayAlert("Error", "You need to select product", "ok");
        }

        [RelayCommand]
        private void HandleSelectionChanged(object SelectedItem)
        {
            BucketItem item = SelectedItem as BucketItem;
            // проверка на то является ли item null
            // такое может произойти если 
            selectedProduct = item != null ? item.Prod : null;
        }


        [RelayCommand]
        private async void ChangeCount()
        {
            if (selectedProduct != null)
            {
                // предлагаем пользвоателю ввести количество товара
                string result = await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayPromptAsync("Buy", "How many items do you want to buy?", initialValue: "1", maxLength: 2, keyboard: Keyboard.Numeric);
                int count = 0;
                // смотрим, дурак ли пользователь(правильно ли он ввел число)
                try
                {
                    count = Convert.ToInt32(result);
                }
                catch
                {
                    await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Invalid input", "Enter only numbers", "ok");
                    return;
                }

                // если все хорошо - удаляем товар со старым количеством и добавляем с нвоым количеством
                model.DeleteProductInBucket(selectedProduct.Id);
                model.AddProductInBucket(selectedProduct.Id, count);

                RefrechObservableCollection();

            }
            else
                await Shell.Current.DisplayAlert("Error", "You need to select product", "ok");
        }

        public async void RefrechObservableCollection()
        {
            // получаем все товары в корзине
            var products = DicToList(model.GetCurrentUser().Bucket);

            //чистим ObservableCollection
            Bucket.Clear();
            // переносим все товары из корзины в
            // ObservableCollection 
            foreach (var product in products)
            {
                await Task.Run(() => Thread.Sleep(100));
                Bucket.Add(product);
            }
        }

        [RelayCommand]
        private async void CreateOrder()
        {
            // нельзя создать заказ с пустой корзиной
            if (Bucket.Count == 0)
            {
                await Shell.Current.DisplayAlert("Warning", "You cant create order with empty bucket", "ok");
                return;
            }

            // получам на чье имя создан заказ
            string buyerFullName;
            // по задумке - если покупатель делает заказа, то он делает заказ на свое имя,
            // а если продавец или админ - он вводит имя того, на кого будет оформлен заказ
            if (model.GetCurrentUser() is Admin || model.GetCurrentUser() is Seller)
                buyerFullName = await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayPromptAsync("Buy", "Enter byer full name", initialValue: "Ivanov Ivan Ivanich", maxLength: 40);
            else
                buyerFullName = model.GetCurrentUser().FullName;

            model.CreateOrder(buyerFullName);
            RefrechObservableCollection();
        }
    }
}
