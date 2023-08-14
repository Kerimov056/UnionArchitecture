using AutoMapper;
using UnionArchitecture.Aplication.DTOs.Basket;
using UnionArchitecture.Aplication.DTOs.Product;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.MapperProfiles;

public class BasketAndProdutProfile : Profile
{
    public BasketAndProdutProfile()
    {
        CreateMap<BasketProductListDto, BasketProduct>().ReverseMap();

        CreateMap<ProductListDto, Car>()
            .ForMember(dest => dest.Marka, opt => opt.MapFrom(src => src.Marka))
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
            .ReverseMap();


        CreateMap<CarGetDTO, Car>().ReverseMap();

    }
}
