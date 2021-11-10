using Myshop.core.Contracts;
using Myshop.core.Models;
using Myshop.core.ViewModels;
using Myshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.services
{
    public class OrderService : IOrderService
    {
        IRepository<Order> OrderContext;
        private readonly Order UpdatedOrder;

        public OrderService(IRepository<Order> OrderContext)
        {
            this.OrderContext = OrderContext;
        }


        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems)
        {
            foreach (var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.Id,
                    Image = item.Image,
                    price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                });
            }

            OrderContext.Insert(baseOrder);
            OrderContext.Commit();
        }

        public List<Order> GetOrderList()
        {
            return OrderContext.Collection().ToList();
        }

        public Order GetOrder(string Id)
        {
            return OrderContext.Find(Id);
        }

        public void UpdateOrder(Order updateOrder)
        {
            OrderContext.Update(UpdatedOrder);
            OrderContext.Commit();
        }
    }
}
