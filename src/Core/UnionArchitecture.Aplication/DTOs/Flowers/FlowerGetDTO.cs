using Microsoft.AspNetCore.Http;

namespace UnionArchitecture.Aplication.DTOs.Flowers;

public record FlowerGetDTO(string name, string image,
                decimal price, string catagory,
                string Description, int SKU,
                string Tags, double Weight,
                string PowerFlowers,
                string ImagePath);
