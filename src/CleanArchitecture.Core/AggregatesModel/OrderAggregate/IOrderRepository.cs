using System.Threading.Tasks;
using CleanArchitecture.Core.SeedWork;

namespace CleanArchitecture.Core.AggregatesModel.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order Add(Order order);
        void Update(Order order);
        Task<Order> GetAsync(int orderId);
    }
}