using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace MIS.Data.Interfaces
{
    public interface IMisRepository
    {
        // CREATE, UPDATE, DELETE
        Task<Guid> CreateAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class, IEntity;
        Task UpdateAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class, IEntity;
        Task DeleteAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : class, IEntity;

        // SEARCH
        Task<T> FindByIdAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : class, IEntity;
        Task<T> SingleAsync<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) where T : class, IEntity;
        Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) where T : class, IEntity;
        Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>>? expression = null, CancellationToken cancellationToken = default) where T : class, IEntity;

        // OTHER
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        void ChangeTracker(QueryTrackingBehavior queryTrackingBehavior);
        void ChangeEntryState<T>(T entity, EntityState entityState = EntityState.Unchanged) where T : class, IEntity;
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
