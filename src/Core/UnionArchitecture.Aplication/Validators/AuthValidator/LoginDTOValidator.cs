using FluentValidation;
using UnionArchitecture.Aplication.DTOs.Auth;

namespace UnionArchitecture.Aplication.Validators.AuthValidator;

public class LoginDTOValidator:AbstractValidator<LoginDTO>
{
	public LoginDTOValidator()
	{
		RuleFor(x=>x.UsernameOrEmail).NotEmpty().NotNull().MaximumLength(255); 
		RuleFor(x=>x.password).NotEmpty().NotNull().MaximumLength(255); 
	}
}
