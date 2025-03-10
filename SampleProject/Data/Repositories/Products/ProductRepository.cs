using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Products
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>();
        }

        public Product Create(Product product)
        {
            var entity = products.FirstOrDefault(x => x.ProductID == product.ProductID);
            if (entity == null)
            {
                products.Add(product);
                return product;
            }
            else
                return null;
        }

        public Product Update(Product product)
        {
            var entity = products.First(x => x.ProductID == product.ProductID);
            entity.SetProductName(product.ProductName);
            entity.SetProductDescription(product.ProductDescription);
            entity.SetUnitPrice(product.UnitPrice);
            entity.SetUnitPrice(product.UnitPrice);
            return entity;
        }

        public bool Delete(Guid productId)
        {
            var entity = products.First(x => x.ProductID == productId);
            products.Remove(entity);
            return true;
        }

        public Product GetById(Guid productId)
        {
            var entity = products.FirstOrDefault(x => x.ProductID == productId);
            return entity;
        }

        public IEnumerable<Product> Get(string productName, string productDescription, decimal? unitPrice, int? unitsInStock)
        {
            var query = products.AsQueryable();

            if (!string.IsNullOrEmpty(productName))
            {
                query = query.Where(x => x.ProductName == productName);
            }

            if (!string.IsNullOrEmpty(productDescription))
            {
                query = query.Where(x => x.ProductDescription == productDescription);
            }

            if(unitPrice != null)
                query = query.Where(x => x.UnitPrice == unitPrice);

            if (unitsInStock != null)
                query = query.Where(x => x.UnitsInStock == unitsInStock);


            return query.ToList();

        }

        public void DeleteAll()
        {
            products.Clear();
        }
    }
}
