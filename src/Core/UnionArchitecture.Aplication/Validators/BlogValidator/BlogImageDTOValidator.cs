using FluentValidation;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Aplication.Validators.BlogValidator;

public class BlogImageDTOValidator : AbstractValidator<Blog>
{
	public BlogImageDTOValidator()
	{
        RuleFor(x => x.ImagePath).NotNull().NotEmpty().MaximumLength(1500);
    }
}
