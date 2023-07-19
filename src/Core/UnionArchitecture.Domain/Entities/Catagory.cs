using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Domain.Entities;

public class Catagory:BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; } 
    public List<Flowers> Flowers { get; set; }
}
