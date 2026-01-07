using Application.Jobs;

namespace Application.Common.Interfaces;

public interface IUnitOfWork
{
    IJobsRepository Jobs { get; }
    
    Task<int> SaveChangesAsync();
}