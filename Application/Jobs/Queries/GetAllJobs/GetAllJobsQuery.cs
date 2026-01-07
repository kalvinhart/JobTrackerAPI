using Application.Jobs.DTOs;
using MediatR;

namespace Application.Jobs.Queries.GetAllJobs;

public record GetAllJobsQuery : IRequest<List<JobDto>>;