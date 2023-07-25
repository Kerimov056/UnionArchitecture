using Microsoft.AspNetCore.Http;

namespace UnionArchitecture.Aplication.DTOs.Slider;

public record SliderCreateDTO(IFormFile imagePath, string title, string description);
