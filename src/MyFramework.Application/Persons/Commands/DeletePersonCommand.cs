using MediatR;
using System;

namespace MyFramework.Application.Persons.Commands
{
    public record DeletePersonCommand(Guid Id) : IRequest<bool>;
}
