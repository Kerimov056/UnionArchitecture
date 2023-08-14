using UnionArchitecture.Aplication.DTOs.Product;

namespace UnionArchitecture.Aplication.DTOs.Basket;

public class BasketProductListDto
{
    public int Quantity { get; set; }
    public Guid BasketId { get; set; }
    public Guid CarId { get; set; }
    public ProductListDto Product { get; set; }

}
