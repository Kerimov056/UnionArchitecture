using FluentValidation;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Aplication.Validators.FlowerValidator;

public class FlowerCreateDTOValidator : AbstractValidator<Flowers>
{
	public FlowerCreateDTOValidator()
	{
        RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(34);
        RuleFor(x => x.ImagePath).NotNull().NotEmpty().MaximumLength(500);
        RuleFor(x => x.Price).NotNull().NotEmpty();
        RuleFor(x => x.FlowersDetails.Description).NotNull().NotEmpty().MaximumLength(280);
        RuleFor(x => x.FlowersDetails.SKU).NotNull().NotEmpty();
        RuleFor(x => x.FlowersDetails.Tags).NotNull().NotEmpty().MaximumLength(60);
        RuleFor(x => x.FlowersDetails.Weight).NotNull().NotEmpty();
        RuleFor(x => x.FlowersDetails.PowerFlowers).NotNull().NotEmpty().MaximumLength(300);
    }
}
