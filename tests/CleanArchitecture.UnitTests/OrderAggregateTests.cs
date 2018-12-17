using System;
using CleanArchitecture.Core.AggregatesModel.OrderAggregate;
using CleanArchitecture.Core.Exceptions;
using Xunit;

namespace CleanArchitecture.UnitTests
{
    public class OrderAggregateTests
    {
        [Fact]
        public void can_add_product_to_order()
        {
            Address address = new Address("Road No. 02", "Dhaka", "Dhaka", "Bangladesh", "1200");
            Order order = new Order(address);
            order.AddProductItem(12, "Mobile", 12000, 1);
            Assert.Equal(1, order.OrderItems.Count);
        }

        [Fact]
        public void expected_error_on_negative_amount_of_item()
        {
            Address address = new Address("Road No. 02", "Dhaka", "Dhaka", "Bangladesh", "1200");
            Order order = new Order(address);

            Assert.Throws<OrderingDomainException>(() => order.AddProductItem(12, "Mobile", 12000, -1));
        }

        [Fact]
        public void get_sum_of_total_added_product()
        {
            // Arrange
            Address address = new Address("Road No. 02", "Dhaka", "Dhaka", "Bangladesh", "1200");
            Order order = new Order(address);
            
            // Act
            order.AddProductItem(12, "Mobile", 12000, 1);
            order.AddProductItem(12, "Mobile", 12000, 1);

            // Assert
            Assert.Equal(24000, order.GetTotal());
        }

        [Fact]
        public void adding_two_same_product_increment_unit_count()
        {
            // Arrange
            Address address = new Address("Road No. 02", "Dhaka", "Dhaka", "Bangladesh", "1200");
            Order order = new Order(address);
            
            // Act
            order.AddProductItem(12, "Mobile", 12000, 1);
            order.AddProductItem(12, "Mobile", 12000, 1);

            // Assert
            Assert.Equal(1, order.OrderItems.Count);
        }

        [Fact]
        public void adding_two_different_product_increment_iteam_count()
        {
            // Arrange
            Address address = new Address("Road No. 02", "Dhaka", "Dhaka", "Bangladesh", "1200");
            Order order = new Order(address);
            
            // Act
            order.AddProductItem(12, "Mobile", 12000, 1);
            order.AddProductItem(13, "Mobile", 12000, 1);

            // Assert
            Assert.Equal(2, order.OrderItems.Count);
        }
    }
}
