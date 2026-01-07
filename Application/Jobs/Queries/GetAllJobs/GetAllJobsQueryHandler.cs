using Application.Common.Interfaces;
using Application.Jobs.DTOs;
using Application.Jobs.Mapping;
using MediatR;

namespace Application.Jobs.Queries.GetAllJobs;

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
        var jobs = await _unitOfWork.Jobs.GetAllJobsAsync(cancellationToken);

        return jobs
            .Select(j => j.MapToDto())
            .ToList();
    }
}