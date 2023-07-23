using AutoMapper;
using UnionArchitecture.Aplication.DTOs.Blog;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.MapperProfiles;

public class BlogImageProfile:Profile
{
	public BlogImageProfile()
	{
		CreateMap<BlogImage,BlogImageCreateDTO>().ReverseMap();
		CreateMap<NewBlogDto, BlogImageCreateDTO>().ReverseMap();
	}
}
