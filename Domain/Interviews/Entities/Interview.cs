using Domain.Common;
using Domain.Interviews.ValueObjects;
using Domain.Jobs.Entities;
using Domain.Jobs.ValueObjects;

namespace Domain.Interviews.Entities;

public class Interview : Auditable
{
    public required InterviewId Id { get; init; }
    public required InterviewDate Date { get; init; }
    public string? Notes { get; init; }
    public required JobId JobId { get; init; }
    public Job Job { get; init; } = null!;
    
    private Interview() {}

    public static Interview From()
    {
        return new Interview
        {
            Id = InterviewId.From(Guid.NewGuid()),
            Date = InterviewDate.From(DateTime.Now),
            JobId = JobId.From(Guid.NewGuid()),
            CreatedDate =  DateTime.UtcNow,
            LastEditedDate = DateTime.UtcNow
        };
    }
}