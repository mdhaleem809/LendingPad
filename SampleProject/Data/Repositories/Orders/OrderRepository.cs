using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> orders;
        private readonly IProductRepository _productRepository;


        public OrderRepository(IProductRepository productRepository)
        {
            orders = new List<Order>();
            _productRepository = productRepository;
        }

        public Tuple<Order, string> Create(Order order)
        {
            var product = _productRepository.GetById(order.ProductId);
            if (product == null)
            {
                return Tuple.Create<Order, string>(null, "Product Not Found");
            }
            var entity = orders.FirstOrDefault(x => x.OrderId == order.OrderId);
            if (entity == null)
            {
                orders.Add(order);
                return Tuple.Create<Order, string>(order, ""); ;
            }
            else
                return Tuple.Create<Order, string>(null, "Order Already Exist");
        }

        public Order Update(Order order)
        {
            var entity = orders.First(x => x.OrderId == order.OrderId);
            entity.SetOrderName(order.OrderName);
            entity.SetProductId(order.ProductId);
            entity.SetPrice(order.Price);
            entity.SetQuantity(order.Quantity);
            return entity;
        }

        public bool Delete(Guid orderId)
        {
            var entity = orders.First(x => x.OrderId == orderId);
            orders.Remove(entity);
            return true;
        }

        public Order GetById(Guid orderId)
        {
            var entity = orders.FirstOrDefault(x => x.OrderId == orderId);
            return entity;
        }

        public IEnumerable<Order> Get(string OrderName, Guid? ProductId, Decimal? Price, int? Quantity)
        {
            var query = orders.AsQueryable();

            if (!string.IsNullOrEmpty(OrderName))
            {
                query = query.Where(x => x.OrderName == OrderName);
            }

            if (!Guid.Empty.Equals(ProductId) && ProductId != null)
            {
                query = query.Where(x => x.ProductId == ProductId);
            }

            if (Price != null)
                query = query.Where(x => x.Price == Price);

            if (Quantity != null)
                query = query.Where(x => x.Quantity == Quantity);


            return query.ToList();

        }

        public void DeleteAll()
        {
            orders.Clear();
        }
    }
}
