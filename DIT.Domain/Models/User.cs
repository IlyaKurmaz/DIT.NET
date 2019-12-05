using DIT.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace DIT.Domain.Models
{
    public sealed class User : IEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<Connector> Connectors { get; set; }
    }
}