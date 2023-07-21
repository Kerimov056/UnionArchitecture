using Microsoft.AspNetCore.Http;

namespace UnionArchitecture.Aplication.DTOs.Flowers;

public record FlowerGetDTO(string name, IFormFile image,
                decimal price,
                string Description, int SKU,
                string Tags, double Weight,
                string PowerFlowers,
                string ImagePath);
