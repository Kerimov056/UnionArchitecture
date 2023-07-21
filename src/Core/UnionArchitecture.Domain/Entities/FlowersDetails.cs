using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Domain.Entities;

public class FlowersDetails : BaseEntity
{
    public string Description { get; set; }
    public int SKU { get; set; }
    public double Weight { get; set; }
    public string PowerFlowers { get; set; }
    public Guid FlowersId { get; set; }
    public Flowers Flowers { get; set; }
    
}
