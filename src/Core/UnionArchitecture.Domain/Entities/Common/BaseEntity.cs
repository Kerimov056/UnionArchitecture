namespace UnionArchitecture.Domain.Entities.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = new Guid();
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set;}
    public virtual bool IsDeleted { get; set;}  
}
