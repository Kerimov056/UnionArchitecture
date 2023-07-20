﻿using AutoMapper;
using UnionArchitecture.Aplication.Abstraction.Repository;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Exceptions;

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
