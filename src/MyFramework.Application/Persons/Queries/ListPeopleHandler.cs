using MediatR;
using MyFramework.Application.Interfaces;
using MyFramework.Application.Persons.Queries;
using MyFramework.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyFramework.Application.Persons.Queries
{
    //public class ListPeopleHandler : IRequestHandler<ListPeopleQuery, IReadOnlyList<Person>>
    //{
    //    private readonly IPersonRepository _repo;
    //    public ListPeopleHandler(IPersonRepository repo) => _repo = repo;

    //    public Task<IReadOnlyList<Person>> Handle(ListPeopleQuery request, CancellationToken cancellationToken)
    //        => _repo.ListAsync(cancellationToken);
    //}
}
