using FluentValidation;

namespace EventCraft.Application.Command.AddUser;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .Length(2, 50);


    }
}