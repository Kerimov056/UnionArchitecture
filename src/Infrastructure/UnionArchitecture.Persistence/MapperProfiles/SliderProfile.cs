using AutoMapper;
using UnionArchitecture.Aplication.DTOs.Slider;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.MapperProfiles;

public class SliderProfile:Profile
{
	public SliderProfile()
	{
		CreateMap<Slider,SliderCreateDTO>().ReverseMap();
		CreateMap<Slider,SliderUptadeDTO>().ReverseMap();
		CreateMap<Slider,SliderGetDTO>().ReverseMap();
	}
}
