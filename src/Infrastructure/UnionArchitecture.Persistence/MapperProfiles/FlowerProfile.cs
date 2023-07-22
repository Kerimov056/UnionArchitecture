using AutoMapper;
using UnionArchitecture.Aplication.DTOs.Flowers;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.MapperProfiles;

public class FlowerProfile:Profile
{
	public FlowerProfile()
	{
		CreateMap<Flowers,FlowerCreateDTO>().ReverseMap();
		CreateMap<Flowers, FlowerDTO>().ReverseMap();
		CreateMap<Flowers,FlowerGetDTO>().ReverseMap();
		CreateMap<Flowers,FlowerUptadeDTO>().ReverseMap();
	}
}
