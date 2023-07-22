using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Domain.Entities;

public class Slider:BaseEntity
{
    public string ImagePath { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
