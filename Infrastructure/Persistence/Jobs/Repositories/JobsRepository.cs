using Application.Jobs;
using Application.Jobs.Specifications;
using Domain.Jobs.Entities;
using Infrastructure.Persistence.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Jobs.Repositories;

public class JobsRepository : GenericRepository<Job>, IJobsRepository
{
    public JobsRepository(DbContext context) : base(context)
    { }

    public async Task<List<Job>> GetAllJobsAsync(CancellationToken cancellationToken)
    {
        var specification = new GetAllJobsSpecification();
        
        return await ListAsync(specification, cancellationToken);
    }
}