using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Product;
using UnionArchitecture.Aplication.DTOs.Slider;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class CarService : ICarService
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;
    public CarService(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task CreateAsync(CarCreateDTO car)
    {
        var Newcar = new Car
        {
            Marka = car.Marka,
            Model = car.Model
        };

        await _appDbContext.AddAsync(Newcar);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<CarGetDTO>> GetAllAsync()
    {
        var cars = await _appDbContext.Cars.ToListAsync();
        if (cars is null) throw new NullReferenceException();
        var EntityToDto = _mapper.Map<List<CarGetDTO>>(cars);
        return EntityToDto;
    }
}
