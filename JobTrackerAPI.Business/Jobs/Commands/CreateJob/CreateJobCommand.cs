using JobTrackerAPI.Business.Jobs.DTOs;
using MediatR;

namespace JobTrackerAPI.Business.Jobs.Commands.CreateJob;

public record CreateJobCommand(CreateJobDto CreateJobDto, Guid UserId) : IRequest<JobDto>;