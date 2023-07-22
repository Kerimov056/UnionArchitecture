using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Aplication.DTOs.TagDTOs;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Aplication.DTOs.Flowers;

public record FlowerGetDTO(string name,
                           string image,
                           decimal price,
                           Guid CatagoryId,
                           FlowerDetailsCreateDTOs FlowerDetailsCreateDTOs,
                           List<FlowersImageDTO> FlowersImageDTO,
                           List<TagGetDTOs> TagGetDTOs,
                           List<Flower_Tag> Flower_Tags);

