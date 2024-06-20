using JobTrackerAPI.DataAccess.Common;
using JobTrackerAPI.DataAccess.Interviews.Entities;
using JobTrackerAPI.DataAccess.Jobs.Enums;

namespace JobTrackerAPI.DataAccess.Jobs.Entities;

public class Job : Auditable
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Location { get; set; }
    public string? Description { get; set; }
    public int? SalaryStart { get; set; }
    public int? SalaryEnd { get; set; }
    public string? ContactName { get; set; }
    public ApplicationStatus Status { get; set; }

    public ICollection<Interview> Interviews { get; set; } = new List<Interview>();
}