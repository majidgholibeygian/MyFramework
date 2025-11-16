using MediatR;
using MyFramework.Domain.Entities;
using System.Collections.Generic;

namespace MyFramework.Application.Persons.Queries
{
    public record ListPeopleQuery() : IRequest<IReadOnlyList<Person>>;
}
