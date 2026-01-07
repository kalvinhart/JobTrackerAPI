namespace API.Extensions;

public static class StringExtensions
{
    public static Guid ToGuid(this string value)
    {
        return Guid.Parse(value);
    }
}