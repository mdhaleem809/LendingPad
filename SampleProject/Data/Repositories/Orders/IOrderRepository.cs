using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IOrderRepository
    {
        Tuple<Order, string> Create(Order order);
        Order Update(Order order);
        bool Delete(Guid orderId);
        Order GetById(Guid orderId);
        IEnumerable<Order> Get(string OrderName, Guid? ProductId, Decimal? Price, int? Quantity);
        void DeleteAll();
    }
}
