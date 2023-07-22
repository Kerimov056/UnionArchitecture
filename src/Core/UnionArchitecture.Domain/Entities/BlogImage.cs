using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Domain.Entities;

public class BlogImage : BaseEntity
{
    public string ImagePath { get; set; }
    //public int BlogId { get; set; }
    //public Blog Blog { get; set; }
}