using CarShowroomSystem.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomSystem.ViewModels
{
    // этот класс нужен, чтобы хранить отдельный элемент корзины - товар и его количество.
    // он нужен, чтобы нормально отобразить корзину, которая хранится у пользователя в качестве
    // словаря
    public class BucketItem
    {
        public Product Prod { get; set; }

        public int Count { get; set; }

    }
}
