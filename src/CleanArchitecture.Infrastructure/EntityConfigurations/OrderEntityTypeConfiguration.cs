using System;
using CleanArchitecture.Core.AggregatesModel.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.EntityConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> orderConfiguration)
        {
            orderConfiguration.ToTable("order", CleanArchitectureContext.DEFAULT_SCHEMA);

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).ForSqlServerUseSequenceHiLo("orderseq", CleanArchitectureContext.DEFAULT_SCHEMA);

            orderConfiguration.OwnsOne(o => o.Address);

            orderConfiguration.Property<DateTime>("OrderDate").IsRequired();

            var navigation = orderConfiguration.Metadata.FindNavigation(nameof(Order.OrderItems));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}