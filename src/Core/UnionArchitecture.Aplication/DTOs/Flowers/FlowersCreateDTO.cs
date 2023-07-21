using Microsoft.AspNetCore.Http;

namespace UnionArchitecture.Aplication.DTOs.Flowers;

public record FlowerCreateDTO(string name, IFormFile image, decimal price, Guid CatagoryId);
