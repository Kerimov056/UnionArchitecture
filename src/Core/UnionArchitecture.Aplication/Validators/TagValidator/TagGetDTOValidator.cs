using FluentValidation;
using UnionArchitecture.Aplication.DTOs.TagDTOs;

namespace UnionArchitecture.Aplication.Validators.TagValidator;

public class TagGetDTOValidator : AbstractValidator<TagCreateDTOs>
{
    public TagGetDTOValidator()
    {
        RuleFor(x => x.tag).NotNull().NotEmpty().MaximumLength(100);
    }
}
