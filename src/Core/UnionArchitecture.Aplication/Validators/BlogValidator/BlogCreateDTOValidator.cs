﻿using FluentValidation;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Aplication.Validators.BlogValidator;

public class BlogCreateDTOValidator : AbstractValidator<Blog>
{
	public BlogCreateDTOValidator()
	{
        RuleFor(x => x.ImagePath).NotNull().NotEmpty().MaximumLength(400);
        RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(40);
        RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(1500);
    }
}
