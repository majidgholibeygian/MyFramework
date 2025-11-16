using MediatR;
using MyFramework.Application.Interfaces;
using MyFramework.Application.Persons.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace MyFramework.Application.Persons.Commands.Handlers
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private readonly IPersonRepository _repo;
        public UpdatePersonHandler(IPersonRepository repo) => _repo = repo;

        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _repo.GetByIdAsync(request.Id, cancellationToken);
            if (person is null) throw new System.InvalidOperationException("Person not found");

            person.SetName(request.FirstName, request.LastName);
            person.SetDateOfBirth(request.DateOfBirth);
            person.SetEmail(request.Email);

            await _repo.UpdateAsync(person, cancellationToken);
            return true;
        }
    }
}
