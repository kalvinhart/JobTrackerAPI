using Domain.Common.ValueObjects;
using Domain.Interviews.Exceptions;

namespace Domain.Interviews.ValueObjects;

public class InterviewId : ValueObject
{
    public Guid Value { get; init; }
    
    private InterviewId() { }
    
    public static InterviewId From(Guid interviewId)
    {
        if (interviewId == Guid.Empty)
        {
            throw new InterviewIdInvalidException();
        }
        
        return new InterviewId
        {
            Value = interviewId
        };
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}