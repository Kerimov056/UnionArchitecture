using Microsoft.AspNetCore.Http;

namespace UnionArchitecture.Aplication.DTOs.Flowers;

public record FlowerUptadeDTO(string name, string image,
                decimal price, Guid CatagoryId //asdadadadad
                );
