using System;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.SeedWork;

namespace CleanArchitecture.Core.AggregatesModel.OrderAggregate
{
    public class OrderItem : Entity
    {
        public string ProductName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Units { get; private set; }

        public int ProductId { get; private set; }

        public OrderItem(int productId, string productName, decimal unitPrice, int units = 1)
        {
            if (units <= 0)
            {
                throw new OrderingDomainException("Invalid number of unit");
            }

            ProductId = productId;

            ProductName = productName;
            UnitPrice = unitPrice;
            Units = units;
        }

        public string GetOrderItemProductName() => ProductName;

        public void AddUnits(int units)
        {
            if (units < 0)
            {
                throw new OrderingDomainException("Invalid unit");
            }

            Units += units;
        }
    }
}