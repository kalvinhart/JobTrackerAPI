using Application.Interviews.Mapping;
using Application.Jobs.DTOs;
using Domain.Jobs.Entities;

namespace Application.Jobs.Mapping;

public static class JobMapper
{
    public static JobDto MapToDto(this Job job)
    {
        return new JobDto(
            Id: job.Id.Value,
            Title: job.Title.Value,
            Location: job.Location.Value,
            Description: job.Description,
            SalaryStart: job.Salary.Start,
            SalaryEnd: job.Salary.End,
            ContactName: job.ContactName?.Value,
            Status: job.Status,
            UserId: job.UserId.Value,
            Interviews: job.Interviews
                    .Select(i => i.MapToDto())
                    .ToList());
    }
}