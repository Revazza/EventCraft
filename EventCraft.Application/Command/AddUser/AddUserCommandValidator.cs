using EventCraft.Application.Common.Extensions;
using FluentValidation;

namespace EventCraft.Application.Command.AddUser;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .MustBeEnglish() //Custom validator 
            .Length(2, 50);

        RuleFor(x => x.Password)
            .NotEmpty()
            .Length(5, 255);

    }
}