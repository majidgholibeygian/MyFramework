using MediatR;
using MyFramework.Application.Interfaces;
using MyFramework.Application.Persons.Queries;
using MyFramework.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyFramework.Application.Persons.Queries
{
    public class GetPersonHandler : IRequestHandler<GetPersonQuery, Person?>
    {
        private readonly IPersonRepository _repo;
        public GetPersonHandler(IPersonRepository repo) => _repo = repo;

        public Task<Person?> Handle(GetPersonQuery request, CancellationToken cancellationToken)
            => _repo.GetByIdAsync(request.Id, cancellationToken);
    }
}
