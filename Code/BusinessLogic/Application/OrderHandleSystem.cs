using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Order CreateOrder(string creatorLogin, string byerFullName, List<Guid> bucket)
        {
            ConnectionCheck();

            Order order = new Order(creatorLogin, byerFullName, bucket);
            DB!.AddOrder(order);
            return order;
        }

        public bool ReturnOrder(Guid id)
        {
            ConnectionCheck();

            Order? order = DB!.GetOrder(id);

            if (order == null) return false;

            order.CancelOrder();
            return DB.ChangeOrder(id, order);
        }

        //проверка подключения БД
        //нужна просто чтобы не забыть про подключение
        private void ConnectionCheck()
        {
            if (DB == null) throw new Exception("У тебя база данных null, дурашка");
        }
    }
}
