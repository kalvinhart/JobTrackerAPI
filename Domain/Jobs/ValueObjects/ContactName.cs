using Domain.Common.ValueObjects;
using Domain.Jobs.Exceptions;

namespace Domain.Jobs.ValueObjects;

public sealed class ContactName : ValueObject
{
    public string? Value { get; private init; }

    private ContactName() { } // EF

    public static ContactName From(string? name)
    {
        if (!string.IsNullOrWhiteSpace(name) && name.Length < 3)
            throw new ContactNameTooShortException();

        return new ContactName
        {
            Value = name
        };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value ?? string.Empty;
    }

    public override string ToString() => Value ?? "";
}