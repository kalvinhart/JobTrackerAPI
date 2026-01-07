using Domain.Common.ValueObjects;
using Domain.Jobs.Exceptions;

namespace Domain.Jobs.ValueObjects;

public sealed class SalaryRange : ValueObject
{
    public int Start { get; private init; }
    public int End { get; private init; }

    private SalaryRange() { } // EF Core

    public static SalaryRange From(int start, int end)
    {
        if (start < 0)
            throw new NegativeSalaryException();

        if (end < start)
            throw new EndSalaryLessThanStartSalaryException();

        return new SalaryRange
        {
            Start = start,
            End = end
        };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }

    public override string ToString() => $"{Start} - {End}";
}