using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Domain.Entities;

public class Flower_Tag
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid FlowersId { get; set; }
    public Flowers Flowers { get; set; }

    public Guid TagsId { get; set; }
    public Tags Tags { get; set; }
}
