
using System;
using System.Collections.Generic;
using BusinessEntities;

namespace WebApi.Models.Products
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}