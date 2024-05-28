using FluentValidation;

namespace Identity.Application.Account.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Имя пользователя обязательное поле")
            .MinimumLength(5).WithMessage("Имя пользователя должен быть не менее 5 символов")
            .MaximumLength(200).WithMessage("Имя пользователя должен быть не более 200 символов");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Пароль обязательное поле")
            .MinimumLength(8).WithMessage("Пароль должен быть не менее 8 символов")
            .MaximumLength(255).WithMessage("Пароль должен быть не более 255 символов");
    }
}