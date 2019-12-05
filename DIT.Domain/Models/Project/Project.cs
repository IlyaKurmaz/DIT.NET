using DIT.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace DIT.Domain.Models
{
    public sealed class Project : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public ICollection<Process> Processes { get; set; }

        public ICollection<ProjectConnector> ProjectConnectors { get; set; }

    }
}