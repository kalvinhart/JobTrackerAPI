using JobTrackerAPI.DataAccess.Common;
using JobTrackerAPI.DataAccess.Jobs.Entities;

namespace JobTrackerAPI.DataAccess.Interviews.Entities;

public class Interview : Auditable
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string? Notes { get; set; }

    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
}