using DIT.Domain.Enums;
using DIT.Domain.Interfaces;
using System;

namespace DIT.Domain.Models
{
    public sealed class FlowContent: IEntity
    {
        public Guid Id { get; set; }

        public string ExecutionOrder { get; set; }

        public bool Status { get; set; }

        public string TargetObject { get; set; }

        public Operation Operation { get; set; }
    }
}