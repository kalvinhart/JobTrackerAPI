using Domain.Common.ValueObjects;
using Domain.Interviews.Exceptions;

namespace Domain.Interviews.ValueObjects;

public sealed class InterviewDate : ValueObject
{
    public DateTime Value { get; private init; }
    
    private InterviewDate() { }

    public static InterviewDate From(DateTime value)
    {
        if (value < DateTime.UtcNow)
            throw new InvalidInterviewDateException();

        return new InterviewDate
        {
            Value = value
        };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd HH:mm:ss");
}