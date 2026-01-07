namespace Domain.Jobs.Exceptions;

public class JobLocationTooShortException : Exception
{
    public JobLocationTooShortException() : base("Job location must contain at least 2 characters.")
    { }
}