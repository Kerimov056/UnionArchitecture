using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Domain.Entities;

public class FlowersImage:BaseEntity
{
    public string ImagePath { get; set; }

    //RelathionsShip
    public int FlowersDetailsId { get; set; }
    public FlowersDetails FlowersDetails { get; set; }
}
