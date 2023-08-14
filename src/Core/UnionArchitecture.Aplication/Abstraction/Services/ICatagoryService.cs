using UnionArchitecture.Aplication.DTOs.Blog;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface ICatagoryService
{
    Task<List<CatagoryGetDTO>> GetAllAsync();
    Task CreateAsync(CatagoryCreateDTO catagoryCreateDTO);
    Task<CatagoryByGetDTO> GetByIdAsync(Guid Id);
    Task UpdateAsync(Guid id, CatagoryUpdateDTO catagoryUpdateDTO);
    Task RemoveAsync(Guid id);
}
