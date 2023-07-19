using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Domain.Entities;

public class Flowers:BaseEntity
{
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public decimal Price { get; set; }

    //RelathionsShip
    public FlowersDetails FlowersDetails { get; set; }
    public int CatagoryId { get; set; }
    public Catagory Catagory { get; set; }

}
