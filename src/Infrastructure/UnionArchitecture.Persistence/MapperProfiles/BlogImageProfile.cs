using AutoMapper;
using UnionArchitecture.Aplication.DTOs.Blog;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.MapperProfiles;

public class BlogImageProfile:Profile
{
	public BlogImageProfile()
	{
		CreateMap<BlogImage,BlogImageCreateDTO>().ReverseMap();
		CreateMap<BlogImage,BlogImageUpdateDTO>().ReverseMap();
		CreateMap<BlogImage, BlogImageGetDTO>().ReverseMap();
		CreateMap<NewBlogDto, BlogImageCreateDTO>().ReverseMap();
		CreateMap<BlogImage, BlogImageGetAllDTO>().ReverseMap();
	}
}
