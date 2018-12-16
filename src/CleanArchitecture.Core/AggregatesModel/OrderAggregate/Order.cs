using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Core.SeedWork;

namespace CleanArchitecture.Core.AggregatesModel.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        private DateTime _orderDate;

        public Address Address { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        protected Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public Order(Address address) : this()
        {
            Address = address;
            _orderDate = DateTime.UtcNow;
        }

        public void AddProductItem(int productId, string productName, decimal unitPrice, int units = 1)
        {
            var existingOrderForProduct = _orderItems.Where(o => o.ProductId == productId).SingleOrDefault();

            if (existingOrderForProduct != null)
            {
                existingOrderForProduct.AddUnits(units);
            }
            else
            {
                var orderItem = new OrderItem(productId, productName, unitPrice, units);
                _orderItems.Add(orderItem);
            }
        }

        public decimal GetTotal()
        {
            return _orderItems.Sum(o => o.GetUnitPrice() * o.GetUnits());
        }
    }
}