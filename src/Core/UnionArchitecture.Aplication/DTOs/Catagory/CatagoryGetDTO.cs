using UnionArchitecture.Aplication.DTOs.Blog;
using UnionArchitecture.Aplication.DTOs.Flowers;

namespace UnionArchitecture.Aplication.DTOs.Catagory;

//public record CatagoryGetDTO(Guid Id, string name, string description,List<FlowerGetDTO> FlowerGetDTOs,List<BlogGetDTO> BlogGetDTOs );



public class CatagoryGetDTO
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
