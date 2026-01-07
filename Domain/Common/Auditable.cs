namespace Domain.Common;

public class Auditable
{
    public DateTime CreatedDate { get; set; }
    public DateTime? LastEditedDate { get; set; }
}