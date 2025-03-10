using System;

namespace BusinessEntities
{
    public class Order
    {
        private Guid _orderId = Guid.NewGuid();
        private string _orderName;
        private Guid _productId;
        private decimal _price;
        private int _quantity;

        public Guid OrderId
        {
            get => _orderId;
            private set => _orderId = value;
        }

        public string OrderName
        {
            get => _orderName;
            private set => _orderName = value;
        }

        public Guid ProductId
        {
            get => _productId;
            private set => _productId = value;
        }

        public decimal Price
        {
            get => _price;
            private set => _price = value;
        }

        public int Quantity
        {
            get => _quantity;
            private set => _quantity = value;
        }

        public void SetOrderId(Guid orderId)
        {
            _orderId = orderId;
        }

        public void SetOrderName(string orderName)
        {
            if (string.IsNullOrEmpty(orderName))
            {
                _orderName = "";
            }
            _orderName = orderName;
        }

        public void SetProductId(Guid productId)
        {
            if (!Guid.Empty.Equals(productId))
            {
                _productId = productId;
            }            
        }

        public void SetPrice(decimal price)
        {
            _price = price;
        }

        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }

    }
}
