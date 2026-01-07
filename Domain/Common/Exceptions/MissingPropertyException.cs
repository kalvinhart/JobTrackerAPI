namespace Domain.Common.Exceptions;

public class MissingPropertyException : Exception
{
    public MissingPropertyException(string propertyName) : base($"Missing property {propertyName}")
    { }
}