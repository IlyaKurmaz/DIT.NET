using DIT.Domain.Interfaces;
using System;

namespace DIT.Domain.Models
{
    public sealed class FlowContent: IEntity
    {
        public Guid Id { get; set; }
    }
}