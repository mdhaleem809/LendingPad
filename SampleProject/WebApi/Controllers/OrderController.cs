using Core.Services.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models.Orders;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : BaseApiController
    {
        private readonly IOrdersService _orderService;

        public OrderController(IOrdersService orderService)
        {
            _orderService = orderService;
        }

        [Route("{id:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(string id, [FromBody] OrderModel model)
        {
            Guid orderId = new Guid(id);
            var resultTuple = _orderService.Create(orderId, model.OrderName, model.ProductId, model.Price, model.Quantity);
            var order = resultTuple.Item1;
            var message = resultTuple.Item2;
            if (order == null)
                return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, message);
            return Found(new OrderData(order));
        }

        [Route("{id:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(string id, [FromBody] OrderModel model)
        {
            Guid orderId = new Guid(id);
            var order = _orderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            order = _orderService.Update(orderId, model.OrderName, model.ProductId, model.Price, model.Quantity);
            return Found(new OrderData(order));
        }

        [Route("{id:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(string id)
        {
            Guid orderId = new Guid(id);

            var order = _orderService.GetOrder(orderId);

            if (order == null)
            {
                return DoesNotExist();
            }
            _orderService.Delete(orderId);
            return Found();
        }

        [Route("GetOrderById")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid orderId)
        {
            var order = _orderService.GetOrder(orderId);
            if (order == null)
                return DoesNotExist();
            else
                return Found(new OrderData(order));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders(string OrderName, Guid? ProductId, Decimal? Price, int? Quantity)
        {
            var orders = _orderService.GetOrder(OrderName, ProductId, Price, Quantity)
                                       .Select(q => new OrderData(q))
                                       .ToList();
            return Found(orders);
        }

    }
}
