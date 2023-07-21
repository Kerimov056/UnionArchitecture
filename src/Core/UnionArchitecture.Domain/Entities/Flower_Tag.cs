namespace UnionArchitecture.Domain.Entities;

public class Flower_Tag
{
    public Guid Id { get; set; }
    public Guid FlowersId { get; set; }
    public Flowers Flowers { get; set; }

    public Guid TagsId { get; set; }
    public Tags TagsTags { get; set; }
}
