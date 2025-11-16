// src/MyFramework.Infrastructure/Repositories/PersonRepository.cs
using Microsoft.EntityFrameworkCore;
using MyFramework.Application.Interfaces;
using MyFramework.Domain.Entities;
using MyFramework.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyFramework.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyFrameworkDbContext _db;
        public PersonRepository(MyFrameworkDbContext db) => _db = db;

        public Task AddAsync(Person person, CancellationToken ct = default)
        {
            _db.People.Add(person);
            return _db.SaveChangesAsync(ct);
        }

        public Task DeleteAsync(Person person, CancellationToken ct = default)
        {
            _db.People.Remove(person);
            return _db.SaveChangesAsync(ct);
        }

        public Task<Person?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => _db.People.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, ct);

        public Task<IReadOnlyList<Person>> ListAsync(CancellationToken ct = default)
            => _db.People.AsNoTracking().ToListAsync(ct).ContinueWith(t => (IReadOnlyList<Person>)t.Result, ct);

        public Task UpdateAsync(Person person, CancellationToken ct = default)
        {
            _db.People.Update(person);
            return _db.SaveChangesAsync(ct);
        }
    }
}