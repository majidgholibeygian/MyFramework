using MyFramework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyFramework.Application.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<IReadOnlyList<Person>> ListAsync(CancellationToken ct = default);
        Task AddAsync(Person person, CancellationToken ct = default);
        Task UpdateAsync(Person person, CancellationToken ct = default);
        Task DeleteAsync(Person person, CancellationToken ct = default);
    }
}
