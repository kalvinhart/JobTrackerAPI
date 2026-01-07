using Ardalis.Specification;
using Domain.Jobs.Entities;

namespace Application.Jobs.Specifications;

public class GetAllJobsSpecification : Specification<Job>
{
    public GetAllJobsSpecification()
    {
        Query
            .OrderByDescending(j => j.CreatedDate)
            .AsNoTracking();
    }
}