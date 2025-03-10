using BusinessEntities;
using Core.Services.Orders;
using Core.Services.Products;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models.Products;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
        private readonly IProductsService _productService;
        private readonly IOrdersService _orderService;

        public ProductController(IProductsService productService, IOrdersService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        [Route("{id:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct(string id, [FromBody] ProductModel model)
        {
            Guid productId = new Guid(id);
            var product = _productService.Create(productId, model.ProductName, model.ProductDescription, model.UnitPrice, model.UnitsInStock);
            if (product == null)
                return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, "Product Already Exist");
            return Found(new ProductData(product));
        }

        [Route("{id:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateProduct(string id, [FromBody] ProductModel model)
        {
            Guid productId = new Guid(id);
            var product = _productService.GetProduct(productId);
            if (product == null)
            {
                return DoesNotExist();
            }
            product = _productService.Update(productId, model.ProductName, model.ProductDescription, model.UnitPrice, model.UnitsInStock);
            return Found(new ProductData(product));
        }

        [Route("{id:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(string id)
        {
            Guid productId = new Guid(id);

            var product = _productService.GetProduct(productId);
            var order = _orderService.GetOrder("", product?.ProductID, null, null);

            if(order!= null && order.Count() > 0 )
            {
                return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, "Product is in use. Please delete Order first.");
            }

            if (product == null)
            {
                return DoesNotExist();
            }
            _productService.Delete(productId);
            return Found();
        }

        [Route("GetProductById")]
        [HttpGet]
        public HttpResponseMessage GetProduct(Guid productId)
        {
            var product = _productService.GetProduct(productId);
            if (product == null)
                return DoesNotExist();
            else
                return Found(new ProductData(product));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetProducts(string productName, string productDescription, decimal? unitPrice, int? unitsInStock)
        {
            var products = _productService.GetProduct(productName, productDescription, unitPrice, unitsInStock)
                                       .Select(q => new ProductData(q))
                                       .ToList();
            return Found(products);
        }

    }
}
