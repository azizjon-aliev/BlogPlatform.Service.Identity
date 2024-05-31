using FluentValidation;
using Identity.Application.Common.Contracts.Repositories;

namespace Identity.Application.Account.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator(IUserRepository repository)
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Имя пользователя обязательное поле")
            .MinimumLength(5).WithMessage("Имя пользователя должен быть не менее 5 символов")
            .MaximumLength(200).WithMessage("Имя пользователя должен быть не более 200 символов")
            .MustAsync(async (username, cancellationToken) =>
            {
                var user = await repository.ExistsAsync(u => u.Username == username, cancellationToken);
                return !user;
            }).WithMessage("Пользователь с таким именем уже существует");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email обязательное поле")
            .EmailAddress().WithMessage("Неверный формат Email")
            .MaximumLength(255).WithMessage("Email должен быть не более 255 символов")
            .MustAsync(async (email, cancellationToken) =>
            {
                var user = await repository.ExistsAsync(u => u.Email == email, cancellationToken);
                return !user;
            }).WithMessage("Пользователь с таким Email уже существует");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Пароль обязательное поле")
            .MinimumLength(8).WithMessage("Пароль должен быть не менее 8 символов")
            .MaximumLength(255).WithMessage("Пароль должен быть не более 255 символов");

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password).WithMessage("Пароли не совпадают");
    }
}