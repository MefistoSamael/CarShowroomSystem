using CarShowroomSystem.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomSystem.ViewModels.Order
{
    [ObservableObject]
    public partial class ViewOrderViewModel : IQueryAttributable
    {
        IModel model;

        [ObservableProperty]
        private ObservableCollection<BucketItem> bucket;

        [ObservableProperty]
        private string creatorUserName;

        [ObservableProperty]
        private string buyerFullName;

        [ObservableProperty]
        private string creationTime;

        [ObservableProperty]
        private string cancellationTime;

        [ObservableProperty]
        private string state;

        [ObservableProperty]
        private decimal price;

        [ObservableProperty]
        private bool isReturned;

        Entities.Order selectedOrder;

        public ViewOrderViewModel(IModel model)
        {
            this.model = model;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            selectedOrder = query["selectedOrder"] as Entities.Order;

            Bucket = new ObservableCollection<BucketItem>(DicToList(model.GetOrderById(selectedOrder.Id).Bucket));
            CreatorUserName = selectedOrder.CreatorUserName;
            BuyerFullName = selectedOrder.BuyerFullName;
            CreationTime = selectedOrder.CreationTime.ToString();
            CancellationTime = selectedOrder.CancellationTime.ToString();
            State = selectedOrder.State.ToString();
            Price = selectedOrder.Price;
            IsReturned = selectedOrder.State == Entities.Order.OrderState.Returned;
        }

        public List<BucketItem> DicToList(Dictionary<Guid, int> dict)
        {
            var list = new List<BucketItem>();

            foreach (var item in dict)
            {
                list.Add(new BucketItem { Prod = model.GetProductById(item.Key), Count = item.Value });
            }

            return list;
        }

    }


}
