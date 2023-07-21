using Microsoft.AspNetCore.Http;

namespace UnionArchitecture.Aplication.DTOs.Flowers;

public record FlowerGetDTO(Guid id,string name, IFormFile image,decimal price,Guid CatagoryId);
