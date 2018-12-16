using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken calcellationToke = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken calcellationToke = default(CancellationToken));
    }
}