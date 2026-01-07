using Domain.Common.ValueObjects;
using Domain.Jobs.Exceptions;

namespace Domain.Jobs.ValueObjects;

public sealed class JobLocation : ValueObject
{
    public required string Value { get; init; }

    private JobLocation() { } // EF

    public static JobLocation From(string location)
    {
        if (location.Length < 3)
            throw new JobLocationTooShortException();

        return new JobLocation
        {
            Value = location
        };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}