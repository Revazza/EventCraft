using EventCraft.Application.Common;
using EventCraft.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EventCraft.Application.Command.AddUser;

public record AddUserRequest(
    string UserName,
    string Email,
    string Password);

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
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is not null)
        {
            return Response.Error($"User with {request.Email} already exists");
        }

        user = new User
        {
            Email = request.Email,
            UserName = request.UserName
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return Response.Error(result.Errors.First().Description);
        }

        return Response.Ok();
    }
}