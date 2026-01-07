namespace Domain.Jobs.Exceptions;

public class EndSalaryLessThanStartSalaryException : Exception
{
    public EndSalaryLessThanStartSalaryException() : base("End salary can not be less than start salary.")
    { }
}