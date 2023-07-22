using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Aplication.DTOs.Slider;

namespace UnionArchitecture.Persistence.Implementations.Services;

public class SliderService : ISliderService
{
    public Task CreateAsync(SliderCreateDTO sliderCreateDTO)
    {
        throw new NotImplementedException();
    }

    public Task<List<SliderGetDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CatagoryGetDTO> GetByIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, SliderUptadeDTO sliderUptadeDTO)
    {
        throw new NotImplementedException();
    }
}
