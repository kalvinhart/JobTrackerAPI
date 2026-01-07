namespace Domain.Jobs.Exceptions;

public class NegativeSalaryException : Exception
{
    public NegativeSalaryException() : base("Salary can not be negative.")
    { }
}