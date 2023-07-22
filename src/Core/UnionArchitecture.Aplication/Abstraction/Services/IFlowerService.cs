using UnionArchitecture.Aplication.DTOs.Flowers;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface IFlowerService
{
    Task<List<FlowerGetDTO>> GetAllAsync();
    Task CreateAsync(FlowerCreateDTO createDTO);
    Task<FlowerDTO> GetByIdAsync(Guid id);
    Task UpdateAsync(Guid id, FlowerDTO flowerDTO);
    Task RemoveAsync(Guid id);
}
