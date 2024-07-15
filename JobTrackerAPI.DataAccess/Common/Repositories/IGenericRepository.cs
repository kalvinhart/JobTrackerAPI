using JobTrackerAPI.DataAccess.Common.DTOs;

namespace JobTrackerAPI.DataAccess.Common.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(ContextGetParameters<T> parameters);
    Task<T?> GetByIdAsync(Guid id);
    void Add(T entity);
    void Remove(T entity);
}