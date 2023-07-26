using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using UnionArchitecture.Aplication.Abstraction.Repository;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Blog;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Exceptions;
using UnionArchitecture.Persistence.Migrations;
using UnionArchitecture.Persistence.Resources;
using Catagory = UnionArchitecture.Domain.Entities.Catagory;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class CatagoryService : ICatagoryService
{
    private readonly ICatagoryReadRepository _CatagoryReadRepository;
    private readonly ICatagoryWriteRepository _CatagoryWriteRepository;
    //private readonly IStringLocalizer<ErrorMessages> _stringLocalizer;
    private readonly IMapper _mapper;

    public CatagoryService(ICatagoryReadRepository catagoryReadRepository,
                           ICatagoryWriteRepository catagoryWriteRepository,
                           //IStringLocalizer<ErrorMessages> stringLocalizer,
                           IMapper mapper)
    {
        _CatagoryReadRepository = catagoryReadRepository;
        _CatagoryWriteRepository = catagoryWriteRepository;
        //_stringLocalizer = stringLocalizer;
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
        //var catagoryGetDTOs = _mapper.Map<List<CatagoryGetDTO>>(catagories);
        //return catagoryGetDTOs; 
        var dtoCatagory = new List<CatagoryGetDTO>();
        foreach (var item in catagories)
        {
            var Catagory = new CatagoryGetDTO
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };
            dtoCatagory.Add(Catagory);
        }
        return dtoCatagory;
    }
    public async Task<CatagoryByGetDTO> GetByIdAsync(Guid Id)
    {
        var catogry = await _CatagoryReadRepository.GetByIdAsync(Id);
        //string message = _stringLocalizer.GetString("NotFoundExceptionMsg");
        //if (catogry is null) throw new NotFoundException("asdad");
        var dtoCatagory = new CatagoryByGetDTO();

        dtoCatagory.Id = catogry.Id;
        dtoCatagory.Name = catogry.Name;
        dtoCatagory.Description = catogry.Description;

        return dtoCatagory;
        //var EntityToDto = _mapper.Map<CatagoryGetDTO>(catogry);
        //return EntityToDto;
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
