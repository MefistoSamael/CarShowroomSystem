using BusinessLogic.Entities;
using BusinessLogic.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application
{
    public class OrderHandleSystem
    {
        public IDBRequestSystem? DB { get; internal set; }

        public OrderHandleSystem()
        {
            DB = null;
        }

        public Order CreateOrder(string creatorLogin, string byerFullName, Dictionary<Guid, int> bucket)
        {
            ConnectionCheck();

            // если забыли где то инициализировать корзину
            if (bucket == null)
                throw new Exception("bucket is null");

            Order order = new Order(creatorLogin, byerFullName, bucket);
            DB!.AddOrder(order);
            return order;
        }

        public Order? ReturnOrder(Guid id)
        {
            ConnectionCheck();

            Order? order = DB!.GetOrder(id);

            if (order == null) return null;

            order.CancelOrder();
            DB.ChangeOrder(id, order);
            return order;
        }

        public decimal CalculateBucketPrice(Dictionary<Guid, int> bucket)
        {
            ConnectionCheck();

            decimal price = 0;
            foreach(Guid key in bucket.Keys) 
            {
                price += DB!.GetProductByGuid(key).Price * bucket[key];
            }

            return price;
        }

        //проверка подключения БД
        //нужна просто чтобы не забыть про подключение
        private void ConnectionCheck()
        {
            if (DB == null) throw new Exception("У тебя база данных null, дурашка");
        }
    }
}
