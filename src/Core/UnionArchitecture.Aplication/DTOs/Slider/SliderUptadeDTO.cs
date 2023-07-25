using Microsoft.AspNetCore.Http;

namespace UnionArchitecture.Aplication.DTOs.Slider;

public record SliderUptadeDTO(IFormFile imagePath, string title, string description);
