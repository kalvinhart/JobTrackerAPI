namespace Domain.Interviews.Exceptions;

public class InterviewIdInvalidException : Exception
{
    public InterviewIdInvalidException() : base("Interview ID is invalid.")
    { }
}