using DIT.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace DIT.Domain.Models
{
    public sealed class Organization : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
