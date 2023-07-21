using Microsoft.AspNetCore.Http;

namespace UnionArchitecture.Aplication.DTOs.Flowers;

public record FlowerCreateDTO(string name, string image,
                decimal price, Guid CatagoryId,
                string Description, int SKU,
                string Tags, double Weight,
                string PowerFlowers,
                string ImagePath);
