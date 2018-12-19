using System;
using System.Threading.Tasks;
using CleanArchitecture.Core.AggregatesModel.OrderAggregate;
using CleanArchitecture.Core.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private CleanArchitectureContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public OrderRepository(CleanArchitectureContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); ;
        }

        public Order Add(Order order)
        {
            return _context.Orders.Add(order).Entity;
        }

        public async Task<Order> GetAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                await _context.Entry(order)
                    .Collection(i => i.OrderItems).LoadAsync();
                await _context.Entry(order)
                    .Reference(i => i.Address).LoadAsync();
            }

            return order;
        }

        public void Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }
    }
}