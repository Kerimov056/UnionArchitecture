using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface ICatagoryService
{
    IQueryable<Catagory> GetAll();
    Task AddAsync(Catagory catagory);
    Task RemoveAsync(string id);
    Task UpdateAsync(Guid id,CatagoryUpdateDTO catagoryUpdateDTO);
}
