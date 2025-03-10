using System;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public string OrderName { get; set; }
        public Guid ProductId { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}