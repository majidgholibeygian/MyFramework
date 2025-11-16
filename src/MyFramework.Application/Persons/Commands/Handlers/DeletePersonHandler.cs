using MediatR;
using MyFramework.Application.Interfaces;
using MyFramework.Application.Persons.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace MyFramework.Application.Persons.Commands.Handlers
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IPersonRepository _repo;
        public DeletePersonHandler(IPersonRepository repo) => _repo = repo;

        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _repo.GetByIdAsync(request.Id, cancellationToken);
            if (person is null) throw new System.InvalidOperationException("Person not found");
            await _repo.DeleteAsync(person, cancellationToken);
            return true;
        }
    }
}
 