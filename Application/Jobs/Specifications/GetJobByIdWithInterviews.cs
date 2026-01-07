using Ardalis.Specification;
using Domain.Jobs.Entities;
using Domain.Jobs.ValueObjects;

namespace Application.Jobs.Specifications;

public class GetJobByIdWithInterviews : Specification<Job>, ISingleResultSpecification<Job>
{
    public GetJobByIdWithInterviews(JobId jobId)
    {
        Query
            .Where(j => j.Id == jobId)
            .Include(j => j.Interviews)
            .OrderByDescending(j => j.CreatedDate);
    }
}