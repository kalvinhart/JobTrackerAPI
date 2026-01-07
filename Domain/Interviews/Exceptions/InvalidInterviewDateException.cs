namespace Domain.Interviews.Exceptions;

public class InvalidInterviewDateException : Exception
{
    public InvalidInterviewDateException() : base("Invalid interview date.")
    { }
}