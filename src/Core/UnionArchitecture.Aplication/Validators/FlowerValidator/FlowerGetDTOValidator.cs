using FluentValidation;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Aplication.Validators.FlowerValidator;

public class FlowerGetDTOValidator : AbstractValidator<Flowers>
{
	public FlowerGetDTOValidator()
	{
        RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(34);
        RuleFor(x => x.ImagePath).NotNull().NotEmpty().MaximumLength(500);
        RuleFor(x => x.Price).NotNull().NotEmpty();
        RuleFor(x => x.Catagory.Name).NotNull().NotEmpty().MaximumLength(34);
        RuleFor(x => x.Catagory.Description).NotNull().NotEmpty().MaximumLength(500);
        RuleFor(x => x.FlowersDetails.Description).NotNull().NotEmpty().MaximumLength(280);
        RuleFor(x => x.FlowersDetails.SKU).NotNull().NotEmpty();
        RuleFor(x => x.FlowersDetails.Weight).NotNull().NotEmpty();
        RuleFor(x => x.FlowersDetails.PowerFlowers).NotNull().NotEmpty().MaximumLength(300);
    }
}
