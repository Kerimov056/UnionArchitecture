using FluentValidation;
using Microsoft.Extensions.Options;
using UnionArchitecture.Aplication.DTOs.Auth;

namespace UnionArchitecture.Aplication.Validators.AuthValidator;

public class RegisterDTOValidator:AbstractValidator<RegisterDTO>
{
	public RegisterDTOValidator()
	{
		RuleFor(u => u.Fullname).MaximumLength(150); 
		RuleFor(u => u.Username).NotEmpty().NotNull().MaximumLength(60);
		RuleFor(u => u.Email).EmailAddress().NotEmpty().NotNull().MaximumLength(80);
		RuleFor(u => u.password).NotEmpty().NotNull().MaximumLength(155);
	}
}
