using FluentValidation;
using UnionArchitecture.Aplication.DTOs.Slider;
using UnionArchitecture.Aplication.DTOs.TagDTOs;

namespace UnionArchitecture.Aplication.Validators.SliderValidator;

public class SliderUptadeDTOValidator : AbstractValidator<SliderUptadeDTO>
{
	public SliderUptadeDTOValidator()
	{
        //RuleFor(x => x.imagePath).NotNull().NotEmpty().MaximumLength(500);
        RuleFor(x => x.title).NotNull().NotEmpty().MaximumLength(50);
        RuleFor(x => x.description).NotNull().NotEmpty().MaximumLength(111);
    }
}
