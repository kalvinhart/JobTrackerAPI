using JobTrackerAPI.Business.Jobs.DTOs;
using JobTrackerAPI.Business.Jobs.Mapping;
using JobTrackerAPI.DataAccess.Common.UnitOfWork;
using MediatR;

namespace JobTrackerAPI.Business.Jobs.Commands.CreateJob;

public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, JobDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateJobCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<JobDto> Handle(
        CreateJobCommand request,
        CancellationToken cancellationToken)
    {
        var newJob = request.CreateJobDto.MapToEntity(request.UserId);

        _unitOfWork.Jobs.Add(newJob);
        await _unitOfWork.SaveChangesAsync();

        return newJob.MapToDto();
    }
}