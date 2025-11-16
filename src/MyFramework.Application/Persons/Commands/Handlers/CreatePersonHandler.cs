using MediatR;
using MyFramework.Application.Interfaces;
using MyFramework.Application.Persons.Commands;
using MyFramework.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyFramework.Application.Persons.Commands.Handlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, System.Guid>
    {
        private readonly IPersonRepository _repo;
        public CreatePersonHandler(IPersonRepository repo) => _repo = repo;

        public async Task<System.Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person(request.FirstName, request.LastName, request.DateOfBirth, request.Email);
            await _repo.AddAsync(person, cancellationToken);
            return person.Id;
        }
    }
}
