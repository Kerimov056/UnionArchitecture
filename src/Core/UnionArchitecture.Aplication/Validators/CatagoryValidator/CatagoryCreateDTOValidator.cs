using FluentValidation;
using UnionArchitecture.Aplication.DTOs.Catagory;

namespace UnionArchitecture.Aplication.Validators.CatagoryValidators;

public class CatagoryCreateDTOValidator : AbstractValidator<CatagoryCreateDTO>
{
    public CatagoryCreateDTOValidator()
    {
        RuleFor(x => x.name).NotNull().NotEmpty().MaximumLength(34);
        RuleFor(x => x.description).NotNull().NotEmpty().MaximumLength(500);
    }
}
