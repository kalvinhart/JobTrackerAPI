using Application.Common.Interfaces;
using Domain.Jobs.Entities;

namespace Application.Jobs;

public interface IJobsRepository : IGenericRepository<Job>
{
    Task<List<Job>> GetAllJobsAsync(CancellationToken cancellationToken);
}