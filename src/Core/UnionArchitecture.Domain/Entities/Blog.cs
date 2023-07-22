using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Domain.Entities;

public class Blog : BaseEntity
{
    public string ImagePath { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CatagoryId { get; set; }
    public Catagory Catagory { get; set; }
    public List<BlogImage> BlogImages { get; set; }
}