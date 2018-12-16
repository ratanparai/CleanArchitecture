using System;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.SeedWork;

namespace CleanArchitecture.Core.AggregatesModel.OrderAggregate
{
    public class OrderItem : Entity
    {
        private string _productName;
        private decimal _unitPrice;
        private int _units;

        public int ProductId { get; private set; }

        public OrderItem(int productId, string productName, decimal unitPrice, int units = 1)
        {
            if (units <= 0)
            {
                throw new OrderingDomainException("Invalid number of unit");
            }

            ProductId = productId;

            _productName = productName;
            _unitPrice = unitPrice;
            _units = units;
        }

        public int GetUnits()
        {
            return _units;
        }

        public decimal GetUnitPrice()
        {
            return _unitPrice;
        }

        public string GetOrderItemProductName() => _productName;

        public void AddUnits(int units)
        {
            if(units < 0)
            {
                throw new OrderingDomainException("Invalid unit");
            }

            _units += units;
        }
    }
}