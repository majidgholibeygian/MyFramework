using MediatR;
using MyFramework.Domain.Entities;
using System;

namespace MyFramework.Application.Persons.Queries
{
    public record GetPersonQuery(Guid Id) : IRequest<Person?>;
}
