using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MIS.Data.Contexts;
using MIS.Data.Interfaces;
using System.Linq.Expressions;

namespace MIS.Data.Repositories
{
    public class MisRepository : IMisRepository
    {
        private readonly MisContext _context;

        public MisRepository(MisContext context)
        {
            _context = context;
        }

        // CREATE, UPDATE, DELETE
        public async Task<Guid> CreateAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class, IEntity
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;

            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} value is missing");
            }

            await _context.Set<T>().AddAsync(entity, cancellationToken);

            return entity.Id;
        }

        public Task UpdateAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class, IEntity
        {
            return Task.Run(() => ChangeEntryState(entity, EntityState.Modified), cancellationToken);
        }

        public async Task DeleteAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : class, IEntity
        {
            var entity = await FindByIdAsync<T>(id, cancellationToken);

            if (entity == null)
            {
                throw new ArgumentNullException($"Entity {nameof(entity)} with id #{id} is missing in database");
            }

            _context.Remove(entity);
        }


        // SEARCH
        public Task<T> FindByIdAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : class, IEntity
        {
            return _context.Set<T>().SingleAsync(entity => entity.Id == id, cancellationToken);
        }

        public async Task<T> SingleAsync<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) where T : class, IEntity
        {
            var entities = await _context.Set<T>().Where(expression).Take(2).ToArrayAsync(cancellationToken);

            if (entities.Length == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }

            if (entities.Length > 1)
            {
                throw new InvalidOperationException("Sequence contains more than one element");
            }

            return entities.Single();
        }

        public Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) where T : class, IEntity
        {
            return _context.Set<T>().FirstOrDefaultAsync(expression, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>>? expression = null, CancellationToken cancellationToken = default) where T : class, IEntity
        {
            var query = expression is null ? _context.Set<T>() : _context.Set<T>().Where(expression);
            return await query.ToArrayAsync(cancellationToken);
        }


        // OTHER
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);

            foreach (var entity in _context.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }
        }

        public void ChangeTracker(QueryTrackingBehavior queryTrackingBehavior)
        {
            _context.ChangeTracker.QueryTrackingBehavior = queryTrackingBehavior;
        }

        public void ChangeEntryState<T>(T entity, EntityState entityState = EntityState.Unchanged) where T : class, IEntity
        {
            var entry = _context.Entry(entity);

            if (entry is null)
            {
                return;
            }

            _context.Set<T>().Attach(entity);

            entry.State = entityState;
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return _context.Database.BeginTransactionAsync();
        }
    }
}
