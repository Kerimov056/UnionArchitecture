using AutoMapper;
using UnionArchitecture.Aplication.DTOs.Flowers;
using UnionArchitecture.Aplication.DTOs.TagDTOs;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.MapperProfiles;

public class TagProfile:Profile
{
	public TagProfile()
	{
        CreateMap<Tags, TagCreateDTOs>().ReverseMap();
        CreateMap<Tags, TagGetDTOs>().ReverseMap();
        CreateMap<Tags, TagUptadeDTO>().ReverseMap();
    }
}
