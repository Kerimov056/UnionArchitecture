using UnionArchitecture.Domain.Entities.Common;
using UnionArchitecture.Domain.Entities.Identity;

namespace UnionArchitecture.Domain.Entities;

public class Basket:BaseEntity
{
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public List<BasketProduct> basketProducts { get; set; }
}
