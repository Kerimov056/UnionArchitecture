using UnionArchitecture.Aplication.DTOs.Blog;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Aplication.DTOs.Flowers;

public class FlowerDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string OnImagePath { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int SKU { get; set; }
    public double Weight { get; set; }
    public string PowerFlowers { get; set; }
    public List<FlowersImageDTO> flowersImageDTOs { get; set; }
    public List<Flower_Tag> Flower_Tag { get; set; }
    public Guid CatagoryId { get; set; }


}
