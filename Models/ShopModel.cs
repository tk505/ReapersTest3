using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ReapersTest3.Models
{
    public class ShopModel
    {
        public async Task<OrderHistoryModel> EnterOrderHistory(ApplicationUser user, DateTime date, string product, decimal value)
        {
            OrderHistoryModel ohm = new OrderHistoryModel() { OrderDate = date, User = user, OrderProduct = product, OrderValue = value };

            return ohm;
        }
    }
}