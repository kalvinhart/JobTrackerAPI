using Application.Common.Interfaces;
using Application.Jobs.DTOs;
using Application.Jobs.Mapping;
using Domain.Jobs.Entities;
using MediatR;

namespace Application.Jobs.Commands.CreateJob;

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
        var newJob = Job.Create(
            jobId: Guid.NewGuid(),
            title: request.CreateJobDto.Title,
            location: request.CreateJobDto.Location,
            salaryStart: request.CreateJobDto.SalaryStart,
            salaryEnd: request.CreateJobDto.SalaryEnd,
            userId: request.UserId,
            interviews: [],
            description: request.CreateJobDto.Description,
            contactName: request.CreateJobDto.ContactName);

        await _unitOfWork.Jobs.AddAsync(newJob, cancellationToken);
        await _unitOfWork.SaveChangesAsync();

        return newJob.MapToDto();
    }
}