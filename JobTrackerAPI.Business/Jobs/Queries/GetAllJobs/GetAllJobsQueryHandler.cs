using JobTrackerAPI.Business.Jobs.DTOs;
using JobTrackerAPI.Business.Jobs.Mapping;
using JobTrackerAPI.DataAccess.Common.UnitOfWork;
using MediatR;

namespace JobTrackerAPI.Business.Jobs.Queries.GetAllJobs;

public class GetAllJobsQueryHandler : IRequestHandler<GetAllJobsQuery, List<JobDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllJobsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<JobDto>> Handle(
        GetAllJobsQuery request,
        CancellationToken cancellationToken)
    {
        var jobs = await _unitOfWork.Jobs.GetAllAsync();

        return jobs
            .Select(j => j.MapToDto())
            .ToList();
    }
}