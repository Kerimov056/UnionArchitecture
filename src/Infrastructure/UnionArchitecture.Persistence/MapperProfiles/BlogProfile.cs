using AutoMapper;
using UnionArchitecture.Aplication.DTOs.Blog;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.MapperProfiles;

public class BlogProfile:Profile
{
	public BlogProfile()
	{
		CreateMap<Blog,BlogGetDTO>().ReverseMap();
		CreateMap<Blog,BlogCreateDTO>().ReverseMap();
		CreateMap<Blog,BlogUpdateDTo>().ReverseMap();
	}
}
