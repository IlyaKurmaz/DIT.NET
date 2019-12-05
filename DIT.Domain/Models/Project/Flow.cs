using DIT.Domain.Interfaces;
using System;

namespace DIT.Domain.Models
{
    public sealed class Flow : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public FlowContent FlowContent { get; set; }

    }
}