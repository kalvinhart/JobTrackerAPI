using JobTrackerAPI.DataAccess.Common.Repositories;
using JobTrackerAPI.DataAccess.Jobs.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.DataAccess.Jobs.Repositories;

public class JobsRepository : GenericRepository<Job>, IJobsRepository
{
    public JobsRepository(DbContext context) : base(context)
    {
    }
}