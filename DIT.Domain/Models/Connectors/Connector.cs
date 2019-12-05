using DIT.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace DIT.Domain.Models
{
    public class Connector : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public bool IsValid { get; set; }

        public User User { get; set; }

        public ICollection<ProjectConnector> ProjectConnectors { get; set; }
    }
}
