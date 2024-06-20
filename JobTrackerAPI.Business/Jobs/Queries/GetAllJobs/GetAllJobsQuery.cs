using JobTrackerAPI.Business.Jobs.DTOs;
using MediatR;

namespace JobTrackerAPI.Business.Jobs.Queries.GetAllJobs;

public record GetAllJobsQuery() : IRequest<List<JobDto>>;