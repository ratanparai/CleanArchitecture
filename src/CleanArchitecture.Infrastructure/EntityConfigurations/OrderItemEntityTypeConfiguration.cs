using CleanArchitecture.Core.AggregatesModel.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.EntityConfigurations
{
    public class OrderItemTypeConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> orderItemConfiguration)
        {
            orderItemConfiguration.ToTable("orderItems", CleanArchitectureContext.DEFAULT_SCHEMA);

            orderItemConfiguration.HasKey(o => o.Id);
            orderItemConfiguration.Property(o => o.Id).ForSqlServerUseSequenceHiLo("orderitemseq", CleanArchitectureContext.DEFAULT_SCHEMA);

            orderItemConfiguration.Property<string>("ProductName").IsRequired();
            orderItemConfiguration.Property<decimal>("UnitPrice").IsRequired();
            orderItemConfiguration.Property<int>("Units").IsRequired();

        }
    }
}