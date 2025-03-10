using BusinessEntities;
using System;

namespace WebApi.Models.Products
{
    public class ProductData 
    {
        public ProductData(Product product)
        {
            ProductId = product.ProductID;
            ProductName = product.ProductName;
            ProductDescription = product.ProductDescription;
            UnitPrice = product.UnitPrice;
            UnitsInStock = product.UnitsInStock;
        }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}