using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface ICatagoryService
{
    Task<List<CatagoryGetDTO>> GetAllAsync();
    Task CreateAsync(CatagoryCreateDTO catagoryCreateDTO);
    Task<CatagoryGetDTO> GetByIdAsync(Guid Id);
    Task UpdateAsync(string id, CatagoryUpdateDTO catagoryUpdateDTO);
    Task RemoveAsync(string id);
}
