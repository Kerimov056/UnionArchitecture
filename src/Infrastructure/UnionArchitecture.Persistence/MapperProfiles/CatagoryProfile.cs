using AutoMapper;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.MapperProfiles;

public class CatagoryProfile:Profile
{
	public CatagoryProfile()
	{
		CreateMap<Catagory,CatagoryCreateDTO>().ReverseMap();
		CreateMap<Catagory,CatagoryGetDTO>().ReverseMap();
		CreateMap<Catagory,CatagoryUpdateDTO>().ReverseMap();
	}
}

