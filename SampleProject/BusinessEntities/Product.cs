using System;

namespace BusinessEntities
{
    public class Product
    {
        private Guid _productID = Guid.NewGuid();
        private string _productName;
        private string _productDescription;
        private decimal _unitPrice;
        private int _unitsInStock;

        public Guid ProductID
        {
            get => _productID;
            private set => _productID = value;
        }

        public string ProductName
        {
            get => _productName;
            private set => _productName = value;
        }

        public string ProductDescription
        {
            get => _productDescription;
            private set => _productDescription = value;
        }

        public decimal UnitPrice
        {
            get => _unitPrice;
            private set => _unitPrice = value;
        }

        public int UnitsInStock
        {
            get => _unitsInStock;
            private set => _unitsInStock = value;
        }

        public void SetProductId(Guid productId)
        {
            _productID = productId;
        }

        public void SetProductName(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                _productName = "";
            }
            _productName = productName;
        }

        public void SetProductDescription(string productDescription)
        {
            if (string.IsNullOrEmpty(productDescription))
            {
                _productDescription = "";
            }
            _productDescription = productDescription;
        }

        public void SetUnitPrice(decimal unitPrice)
        {
            _unitPrice = unitPrice;
        }

        public void SetUnitsInStock(int unitsInStock)
        {
            _unitsInStock = unitsInStock;
        }

    }
}
