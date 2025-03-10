using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Users;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class OrdersService : IOrdersService
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Tuple<Order, string> Create(Guid orderId, string OrderName, Guid ProductId, decimal Price, int Quantity)
        {
            Order order = new Order();
            order.SetOrderId(orderId);
            order.SetOrderName(OrderName);
            order.SetProductId(ProductId);
            order.SetPrice(Price);
            order.SetQuantity(Quantity);
            var result = _orderRepository.Create(order);
            return result;
        }

        public Order Update(Guid orderId, string OrderName, Guid ProductId, decimal Price, int Quantity)
        {
            Order order = _orderRepository.GetById(orderId);
            order.SetOrderId(orderId);
            order.SetOrderName(OrderName);
            order.SetProductId(ProductId);
            order.SetPrice(Price);
            order.SetQuantity(Quantity);
            _orderRepository.Update(order);
            return order;
        }
        public bool Delete(Guid orderId)
        {
            bool result = _orderRepository.Delete(orderId);
            return result;
        }
        public Order GetOrder(Guid orderId)
        {
            Order order = _orderRepository.GetById(orderId);
            return order;
        }
        public IEnumerable<Order> GetOrder(string OrderName, Guid? ProductId, Decimal? Price, int? Quantity)
        {
            IEnumerable<Order> order = _orderRepository.Get(OrderName, ProductId, Price, Quantity);
            return order;
        }


    }
}
