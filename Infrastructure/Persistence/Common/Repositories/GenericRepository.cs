using Application.Common.Interfaces;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Common.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _db;

    public GenericRepository(DbContext dbContext)
    {
        _db = dbContext;
    }

    public async Task<T?> GetAsync(Specification<T> specification, CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<T>> ListAsync(Specification<T> specification, CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _db.Set<T>().AddAsync(entity, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _db.Set<T>().Update(entity);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAsync(T entity, CancellationToken cancellationToken)
    {
        _db.Set<T>().Remove(entity);
        await _db.SaveChangesAsync(cancellationToken);
    }
    
    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator.Default
            .GetQuery(_db.Set<T>().AsQueryable(), spec);
    }
}