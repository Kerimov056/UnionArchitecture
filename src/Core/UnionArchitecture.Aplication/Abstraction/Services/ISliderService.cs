using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Aplication.DTOs.Slider;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface ISliderService
{
    Task<List<SliderGetDTO>> GetAllAsync();
    Task CreateAsync(SliderCreateDTO sliderCreateDTO);
    Task<CatagoryGetDTO> GetByIdAsync(Guid Id);
    Task UpdateAsync(Guid id, SliderUptadeDTO sliderUptadeDTO);
    Task RemoveAsync(Guid id);
}
