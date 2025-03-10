using BusinessEntities;
using System;
using System.Collections.Generic;

namespace Core.Services.Orders
{
    public interface IOrdersService
    {
        Tuple<Order, string> Create(Guid orderId, string OrderName, Guid ProductId, decimal Price, int Quantity);
        Order Update(Guid orderId, string OrderName, Guid ProductId, decimal Price, int Quantity);
        bool Delete(Guid orderId);
        Order GetOrder(Guid orderId);
        IEnumerable<Order> GetOrder(string OrderName, Guid? ProductId, Decimal? Price, int? Quantity);
    }
}
