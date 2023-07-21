using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Domain.Entities;

public class Tags:BaseEntity
{
    public string Tag { get; set; }
    public List<Flower_Tag> Flower_Tags { get; set; }
}
