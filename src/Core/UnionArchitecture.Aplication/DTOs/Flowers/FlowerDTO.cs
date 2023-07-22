using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Aplication.DTOs.Flowers;

public class FlowerDTO
{
    public string Name { get; set; }
    public string OnImagePath { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int SKU { get; set; }
    public double Weight { get; set; }
    public string PowerFlowers { get; set; }
    public string OffImagePath { get; set; }
    //public string Tag { get; set; }
    public List<string> ByTags { get; set; }
    public Guid CatagoryId { get; set; }


    //public List<string> Tags()
    //{
    //    List<Flower_Tag> flower_Tags;

    //    foreach (var item in )
    //    {
    //        if (item)
    //        {

    //        }
    //    }
    //    return;
    //}
}
