namespace Domain.Jobs.Exceptions;

public class JobTitleTooShortException : Exception
{
    public JobTitleTooShortException() : base("Title must contain at least 3 characters.") 
    { }
}