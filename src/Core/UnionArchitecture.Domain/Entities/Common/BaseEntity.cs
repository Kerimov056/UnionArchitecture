namespace UnionArchitecture.Domain.Entities.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set;}
    public virtual bool IsDeleted { get; set;}  
}
