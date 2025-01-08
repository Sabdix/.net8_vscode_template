using FluentValidation;

namespace Application.Commands.Authenticate
{
  public class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand>
  {
    public AuthenticateCommandValidator()
    {
      RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
      RuleFor(x => x.Password).NotNull().NotEmpty();
    }
  }
}