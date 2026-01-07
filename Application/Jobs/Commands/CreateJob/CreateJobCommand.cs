using Application.Jobs.DTOs;
using MediatR;

namespace Application.Jobs.Commands.CreateJob;

public record CreateJobCommand(CreateJobDto CreateJobDto, Guid UserId) : IRequest<JobDto>;