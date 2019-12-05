using DIT.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace DIT.Domain.Models
{
    public sealed class Process: IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ProcessContent ProcessContent { get; set; }

        public ICollection<Flow> Flows { get; set; }
    }
}