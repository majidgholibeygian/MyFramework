// src/MyFramework.Domain/Entities/Person.cs
using System;

namespace MyFramework.Domain.Entities
{
    public sealed class Person
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Email { get; private set; }

        private Person() { } // for EF

        public Person(string firstName, string lastName, DateTime dateOfBirth, string email)
        {
            Id = Guid.NewGuid();
            SetName(firstName, lastName);
            SetDateOfBirth(dateOfBirth);
            SetEmail(email);
        }

        public void SetName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("FirstName is required", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("LastName is required", nameof(lastName));
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
        }

        public void SetDateOfBirth(DateTime dob)
        {
            if (dob > DateTime.UtcNow) throw new ArgumentException("DateOfBirth cannot be in the future", nameof(dob));
            DateOfBirth = dob;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email is required", nameof(email));
            // simple validation
            if (!email.Contains("@")) throw new ArgumentException("Email is invalid", nameof(email));
            Email = email.Trim();
        }
    }
}