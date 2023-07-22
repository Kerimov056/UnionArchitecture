using FluentValidation;
using UnionArchitecture.Aplication.DTOs.TagDTOs;

namespace UnionArchitecture.Aplication.Validators.TagValidator;

public class TagUptadeDTOValidator : AbstractValidator<TagUptadeDTO>
{
    public TagUptadeDTOValidator()
    {
        RuleFor(x => x.tag).NotNull().NotEmpty().MaximumLength(100);
    }
}
