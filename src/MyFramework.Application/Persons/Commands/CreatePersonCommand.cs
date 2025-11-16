using MediatR;
using MyFramework.Domain.Entities;
using System;

namespace MyFramework.Application.Persons.Commands
{
    public record CreatePersonCommand(string FirstName, string LastName, DateTime DateOfBirth, string Email) : IRequest<Guid>;
}
