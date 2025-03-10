using BusinessEntities;
using System;

namespace WebApi.Models.Orders
{
    public class OrderData
    {
        public OrderData(Order order)
        {
            OrderId = order.OrderId;
            OrderName = order.OrderName;
            ProductId = order.ProductId;
            Price = order.Price;
            Quantity = order.Quantity;
        }

        public Guid OrderId { get; set; }
        public string OrderName { get; set; }
        public Guid ProductId { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}