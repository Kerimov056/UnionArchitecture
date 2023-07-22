using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Domain.Entities;

public class Flowers : BaseEntity
{
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public decimal Price { get; set; }

    //RelathionsShip
    public Guid CatagoryId { get; set; }
    public FlowersDetails FlowersDetails { get; set; }
    public Catagory Catagory { get; set; }
    public List<FlowersImage> Images { get; set; }
    public List<Flower_Tag> Flower_Tags { get; set; }
}



//public string Tags { get; set; }