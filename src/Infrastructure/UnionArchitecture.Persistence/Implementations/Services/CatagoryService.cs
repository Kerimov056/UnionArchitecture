using AutoMapper;
using UnionArchitecture.Aplication.Abstraction.Repository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class CatagoryService : ICatagoryService
{
    public Task CreateAsync(CatagoryCreateDTO catagoryCreateDTO)
    {
        throw new NotImplementedException();
    }

    public Task<List<CatagoryGetDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CatagoryGetDTO> GetByIdAsync(string Id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string id, CatagoryUpdateDTO catagoryUpdateDTO)
    {
        throw new NotImplementedException();
    }
}
