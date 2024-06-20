using JobTrackerAPI.DataAccess.Jobs.Repositories;

namespace JobTrackerAPI.DataAccess.Common.UnitOfWork;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    IJobsRepository Jobs { get; }
}