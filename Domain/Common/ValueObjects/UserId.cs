using Domain.Common.Exceptions;

namespace Domain.Common.ValueObjects;

public class UserId : ValueObject
{
    public Guid Value { get; private init; }

    private UserId() {}
    
    public static UserId From(Guid value)
    {
        if (value == Guid.Empty) 
            throw new UserIdInvalidException();

        return new UserId
        {
            Value = value
        };
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}