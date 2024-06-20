using JobTrackerAPI.DataAccess.Common.Repositories;
using JobTrackerAPI.DataAccess.Jobs.Entities;

namespace JobTrackerAPI.DataAccess.Jobs.Repositories;

public interface IJobsRepository : IGenericRepository<Job>
{

}