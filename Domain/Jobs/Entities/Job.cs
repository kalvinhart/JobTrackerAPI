using Domain.Common;
using Domain.Common.ValueObjects;
using Domain.Interviews.Entities;
using Domain.Jobs.Enums;
using Domain.Jobs.ValueObjects;

namespace Domain.Jobs.Entities;

public class Job : Auditable
{
    public required JobId Id { get; init; }
    public required JobTitle Title { get; init; }
    public required JobLocation Location { get; init; }
    public string? Description { get; init; }
    public required SalaryRange Salary { get; init; }
    public ContactName? ContactName { get; init; }
    public ApplicationStatus Status { get; init; }
    public required UserId UserId { get; init; }
    public ICollection<Interview> Interviews { get; init; } = [];
    
    private Job() {}
    
    public static Job Create(
        Guid jobId,
        string title,
        string location,
        int salaryStart,
        int salaryEnd,
        Guid userId,
        List<Interview> interviews,
        string? description = null,
        string? contactName = null)
    {
        return new Job
        {
            Id = JobId.From(jobId),
            Title = JobTitle.From(title),
            Location = JobLocation.From(location),
            Salary = SalaryRange.From(salaryStart, salaryEnd),
            UserId = UserId.From(userId),
            Description = description,
            ContactName = ContactName.From(contactName),
            Status = ApplicationStatus.Pending, // default status
            Interviews = interviews,
            CreatedDate =  DateTime.UtcNow,
            LastEditedDate = DateTime.UtcNow
        };
    }
}