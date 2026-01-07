namespace Domain.Jobs.Exceptions;

public class ContactNameTooShortException : Exception
{
    public ContactNameTooShortException()  : base("Contact name must contain at least 3 characters.")
    { }
}