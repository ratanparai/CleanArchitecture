using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.AggregatesModel.OrderAggregate;
using CleanArchitecture.Core.SeedWork;
using CleanArchitecture.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure
{
    public class CleanArchitectureContext : DbContext, IUnitOfWork
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public const string DEFAULT_SCHEMA = "cleanarchitecuture";


        public CleanArchitectureContext(DbContextOptions<CleanArchitectureContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken calcellationToke = default(CancellationToken))
        {
            // TODO Dispatch domain events

            // Save states
            await base.SaveChangesAsync();

            return true;
        }
    }
}