using Domain.Common.ValueObjects;
using Domain.Jobs.Exceptions;

namespace Domain.Jobs.ValueObjects;

public sealed class JobTitle : ValueObject
{
    public required string Value { get; init; }

    private JobTitle() { } // EF

    public static JobTitle From(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new MissingFieldException("Job Title");

        if (title.Length < 4)
            throw new JobTitleTooShortException();

        return new JobTitle
        {
            Value = title
        };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}