using JobTrackerAPI.Business.Interviews.Mapping;
using JobTrackerAPI.Business.Jobs.DTOs;
using JobTrackerAPI.DataAccess.Jobs.Entities;
using JobTrackerAPI.DataAccess.Jobs.Enums;

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
            UserId: job.UserId,
            Interviews: job.Interviews != null
                ? job.Interviews
                    .Select(i => i.MapToDto())
                    .ToList()
                : []);
    }

    public static Job MapToEntity(this CreateJobDto jobDto, Guid userId)
    {
        return new Job
        {
            Id = Guid.NewGuid(),
            Title = jobDto.Title,
            Location = jobDto.Location,
            Description = jobDto.Description,
            SalaryStart = jobDto.SalaryStart,
            SalaryEnd = jobDto.SalaryEnd,
            ContactName = jobDto.ContactName,
            Status = ApplicationStatus.Pending,
            UserId = userId
        };
    }
}