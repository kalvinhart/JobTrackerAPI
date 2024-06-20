using JobTrackerAPI.Business.Interviews.Mapping;
using JobTrackerAPI.Business.Jobs.DTOs;
using JobTrackerAPI.DataAccess.Jobs.Entities;

namespace JobTrackerAPI.Business.Jobs.Mapping;

public static class JobMapper
{
    public static JobDto MapToDto(this Job job)
    {
        return new JobDto(
            Id: job.Id,
            Title: job.Title,
            Location: job.Location,
            Description: job.Description,
            SalaryStart: job.SalaryStart,
            SalaryEnd: job.SalaryEnd,
            ContactName: job.ContactName,
            Status: job.Status,
            Interviews: job.Interviews
                .Select(i => i.MapToDto())
                .ToList());
    }
}