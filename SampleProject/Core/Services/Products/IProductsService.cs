using BusinessEntities;
using System;
using System.Collections.Generic;

namespace Core.Services.Products
{
    public interface IProductsService
    {
        Product Create(Guid productId, string productName, string productDescription, decimal unitPrice, int unitsInStock);
        Product Update(Guid productId, string productName, string productDescription, decimal unitPrice, int unitsInStock);
        bool Delete(Guid productId);
        Product GetProduct(Guid productId);
        IEnumerable<Product> GetProduct(string productName, string productDescription, decimal? unitPrice, int? unitsInStock);
    }
}
