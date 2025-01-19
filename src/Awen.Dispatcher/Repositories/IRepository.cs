namespace Awen.Dispatcher.Repositories;

public interface IRepository<TEntity> where TEntity: class
{
    Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
