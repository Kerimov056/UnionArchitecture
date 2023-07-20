using AutoMapper;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Aplication.Mappers;

public class CatagoryMapper:Profile
{
	public CatagoryMapper()
	{
		CreateMap<Catagory,CatagoryUpdateDTO>().ReverseMap();
	}
}
