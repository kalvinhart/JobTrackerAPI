namespace Domain.Jobs.Exceptions;

public class JobIdInvalidException : Exception
{
    public JobIdInvalidException() : base("Job ID is invalid.")
    { }
}