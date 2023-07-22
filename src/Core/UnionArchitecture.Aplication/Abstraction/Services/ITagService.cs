using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Aplication.DTOs.TagDTOs;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface ITagService
{
    Task<List<TagGetDTOs>> GetAllAsync();
    Task CreateAsync(TagCreateDTOs tagCreateDTOs);
    Task<TagGetDTOs> GetByIdAsync(Guid Id);
    Task UpdateAsync(Guid id, TagUptadeDTO tagUptadeDTO);
    Task RemoveAsync(Guid id);
}
