namespace Domain.Common.Exceptions;

public class UserIdInvalidException : Exception
{
    public UserIdInvalidException() : base("User ID is invalid.")
    { }
}