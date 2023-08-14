using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Domain.Entities;

public class BasketProduct:BaseEntity
{
    public int Quantity { get; set; }
    public Guid BasketId { get; set; }
    public  Basket Basket { get; set; }
    public Guid CarId { get; set; }
    public Car Car { get; set; }
}
