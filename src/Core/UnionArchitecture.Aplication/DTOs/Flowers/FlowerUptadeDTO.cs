using Microsoft.AspNetCore.Http;
using UnionArchitecture.Aplication.DTOs.TagDTOs;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Aplication.DTOs.Flowers;

public record FlowerUptadeDTO(string name, string image,
                decimal price, Guid CatagoryId,
                FlowerDetailsCreateDTOs FlowerDetailsCreateDTOs,
                FlowersImageDTO FlowersImageDTO,
                Flower_Tag Flower_Tag,
                TagCreateDTOs TagDTOs);
