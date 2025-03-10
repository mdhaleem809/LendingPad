using BusinessEntities;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IProductRepository 
    {
        Product Create(Product product);
        Product Update(Product product);
        bool Delete(Guid productId);
        Product GetById(Guid productId);
        IEnumerable<Product> Get(string productName, string productDescription, decimal? unitPrice, int? unitsInStock);
        void DeleteAll();
    }
}
