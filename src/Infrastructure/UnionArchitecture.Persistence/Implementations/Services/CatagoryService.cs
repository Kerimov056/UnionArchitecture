using AutoMapper;
using UnionArchitecture.Aplication.Abstraction.Repository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class CatagoryService : ICatagoryService
{
    private readonly IReadRepository<Catagory> _readRepository;
    private readonly IWriteRepository<Catagory> _writeRepository;
    //private readonly IMapper _mapper;
    public CatagoryService(
        IReadRepository<Catagory> readRepository,
        IWriteRepository<Catagory> writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        //_mapper = mapper;
    }
    public IQueryable<Catagory> GetAll()
    {
        var query = _readRepository.GetAll();
        return query;
    }

    public async Task AddAsync(Catagory catagory)
    {
        if (catagory is null) throw new NullReferenceException();
        await _writeRepository.AddAsync(catagory);
        await _writeRepository.SaveChangeAsync();   

    }

    public async Task RemoveAsync(string id)
    {
        var catagory = await _readRepository.GetByIdAsync(new Guid(id)
);
        if (catagory is not null)
        {
            _writeRepository.Remove(catagory);
            await _writeRepository.SaveChangeAsync();
        }
    }

    public async Task UpdateAsync(Guid id, CatagoryUpdateDTO catagoryUpdateDTO)
    {
        if (catagoryUpdateDTO is null) throw new NullReferenceException();
        var catagory = await _readRepository.GetByIdAsync(id);
        if (catagory is null) throw new NullReferenceException();

        //var obj = _mapper.Map<Catagory>(catagoryUpdateDTO);
        Catagory obj = new()
        {
            Name = catagoryUpdateDTO.Name,
            Description = catagoryUpdateDTO.Description
        };
        _writeRepository.Update(obj);
        await _writeRepository.SaveChangeAsync();
    }
}
