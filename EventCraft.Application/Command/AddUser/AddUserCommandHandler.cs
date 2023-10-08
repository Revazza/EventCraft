using EventCraft.Application.Common;
using EventCraft.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EventCraft.Application.Command.AddUser;


public record AddUserCommand(
    string UserName,
    string Email,
    string Password) : IRequest<Response>;


public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Response>
{
    private readonly UserManager<User> _userManager;

    public AddUserCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Response> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {

        return Response.Ok();
    }
}