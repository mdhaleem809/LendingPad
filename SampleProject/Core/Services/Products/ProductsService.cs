using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;

namespace Core.Services.Products
{
    [AutoRegister]
    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _productRepository;

        public ProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Create(Guid productId, string productName, string productDescription, decimal unitPrice, int unitsInStock)
        {
            Product product = new Product();
            product.SetProductId(productId);
            product.SetProductName(productName);
            product.SetProductDescription(productDescription);
            product.SetUnitPrice(unitPrice);
            product.SetUnitsInStock(unitsInStock);
            var result = _productRepository.Create(product);
            return result;
        }

        public Product Update(Guid productId, string productName, string productDescription, decimal unitPrice, int unitsInStock)
        {
            Product product = _productRepository.GetById(productId);
            product.SetProductId(productId);
            product.SetProductName(productName);
            product.SetProductDescription(productDescription);
            product.SetUnitPrice(unitPrice);
            product.SetUnitsInStock(unitsInStock);
            _productRepository.Update(product);
            return product;
        }
        public bool Delete(Guid productId)
        {
            bool result = _productRepository.Delete(productId);
            return result;
        }
        public Product GetProduct(Guid productId)
        {
            Product product = _productRepository.GetById(productId);
            return product;
        }
        public IEnumerable<Product> GetProduct(string productName, string productDescription, decimal? unitPrice, int? unitsInStock)
        {
            IEnumerable<Product> product = _productRepository.Get(productName, productDescription, unitPrice, unitsInStock);
            return product;
        }

        
    }
}
