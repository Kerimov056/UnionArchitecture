using FluentValidation;
using UnionArchitecture.Aplication.DTOs.Catagory;

namespace UnionArchitecture.Aplication.Validators.CatagoryValidator;

public class CatagoryUptadeDTOValidator: AbstractValidator<CatagoryCreateDTO>
{
	public CatagoryUptadeDTOValidator()
	{
        RuleFor(x => x.name).NotNull().NotEmpty().MaximumLength(34);
        RuleFor(x => x.description).NotNull().NotEmpty().MaximumLength(500);
    }
}
