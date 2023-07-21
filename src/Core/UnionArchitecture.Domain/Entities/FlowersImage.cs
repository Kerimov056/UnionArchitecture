using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Domain.Entities;

public class FlowersImage : BaseEntity
{
    public string ImagePath { get; set; }

    //RelathionsShip
    public Guid FlowersId { get; set; }
    public Flowers Flowers { get; set; }
}
