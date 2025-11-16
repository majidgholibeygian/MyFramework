using MediatR;
using System;

namespace MyFramework.Application.Persons.Commands
{
    public record UpdatePersonCommand(Guid Id, string FirstName, string LastName, DateTime DateOfBirth, string Email) : IRequest<bool>;
}
