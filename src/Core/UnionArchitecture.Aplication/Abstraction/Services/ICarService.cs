using UnionArchitecture.Aplication.DTOs.Product;
using UnionArchitecture.Aplication.DTOs.Slider;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface ICarService
{
    Task CreateAsync(CarCreateDTO car);
    Task<List<CarGetDTO>> GetAllAsync();
}
