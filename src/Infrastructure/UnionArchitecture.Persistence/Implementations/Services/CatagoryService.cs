using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UnionArchitecture.Aplication.Abstraction.Repository;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Exceptions;
using UnionArchitecture.Persistence.Migrations;
using Catagory = UnionArchitecture.Domain.Entities.Catagory;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class CatagoryService : ICatagoryService
{
    private readonly ICatagoryReadRepository _CatagoryReadRepository;
    private readonly ICatagoryWriteRepository _CatagoryWriteRepository;
    private readonly IMapper _mapper;

    public CatagoryService(ICatagoryReadRepository catagoryReadRepository, ICatagoryWriteRepository catagoryWriteRepository, IMapper mapper)
    {
        _CatagoryReadRepository = catagoryReadRepository;
        _CatagoryWriteRepository = catagoryWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(CatagoryCreateDTO catagoryCreateDTO)
    {
        Catagory? catagory = await _CatagoryReadRepository
             .GetByIdAsyncExpression(c => c.Name.ToLower().Equals(catagoryCreateDTO.name));
        if (catagory is not null) throw new DublicatedException("Dubilcated Catagory Name!");
        Catagory newCatagory = _mapper.Map<Catagory>(catagoryCreateDTO);
        await _CatagoryWriteRepository.AddAsync(newCatagory);
        await _CatagoryWriteRepository.SaveChangeAsync();
    }

    public async Task<List<CatagoryGetDTO>> GetAllAsync()
    {
        var catagories = await _CatagoryReadRepository.GetAll().ToListAsync();
        var catagoryGetDTOs = _mapper.Map<List<CatagoryGetDTO>>(catagories);
        return catagoryGetDTOs;
    }
    public async Task<CatagoryGetDTO> GetByIdAsync(Guid Id)
    {
        var catogry = await _CatagoryReadRepository.GetByIdAsync(Id);
        if (catogry is null) throw new NullReferenceException("There is no catagory with this name");
        var EntityToDto = _mapper.Map<CatagoryGetDTO>(catogry);
        return EntityToDto;
    }

    public async Task RemoveAsync(Guid id)
    {
        var category = await _CatagoryReadRepository.GetByIdAsync(id);
        if (category is null) throw new NullReferenceException("There is no catagory with this name");
        _CatagoryWriteRepository.Remove(category);
        await _CatagoryWriteRepository.SaveChangeAsync();
    }

    public async Task UpdateAsync(Guid id, CatagoryUpdateDTO catagoryUpdateDTO)
    {
        var category = await _CatagoryReadRepository.GetByIdAsync(id);
        if (category is null) throw new NullReferenceException("There is no catagory with this name");
        _mapper.Map(catagoryUpdateDTO, category);
        _CatagoryWriteRepository.Update(category);
        await _CatagoryWriteRepository.SaveChangeAsync();
    }

}
