using Ardalis.Specification;

namespace Application.Common.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetAsync(Specification<T> specification, CancellationToken cancellationToken);
    Task<List<T>> ListAsync(Specification<T> specification, CancellationToken cancellationToken);
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task RemoveAsync(T entity, CancellationToken cancellationToken);
}