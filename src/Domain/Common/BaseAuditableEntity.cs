namespace Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; } = DateTime.Now;

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}