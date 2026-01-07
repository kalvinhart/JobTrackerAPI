using Domain.Common.ValueObjects;
using Domain.Jobs.Exceptions;

namespace Domain.Jobs.ValueObjects;

public sealed class JobId : ValueObject
{
    public Guid Value { get; init; }
    
    private JobId() { }
    
    public static JobId From(Guid jobId)
    {
        if (jobId == Guid.Empty)
        {
            throw new JobIdInvalidException();
        }
        
        return new JobId
        {
            Value = jobId
        };
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}