using UnionArchitecture.Aplication.DTOs.Basket;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface IBasketService
{
    Task AddBasketAsync(Guid Id);
    Task<List<BasketProductListDto>> GetBasketProductsAsync();
    Task DeleteBasketAsync(Guid id);
    Task<int> GetBasketCountAsync();
    Task DeleteBasketItemAsync(Guid id);
    Task<int> GetItemBasketCount(Guid id);
}
