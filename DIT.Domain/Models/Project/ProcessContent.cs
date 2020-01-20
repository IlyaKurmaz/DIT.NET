using DIT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIT.Domain.Models
{
    public sealed class ProcessContent: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte ExecutionOrder { get; set; }
        public bool Status { get; set; }
        public string CronSettings { get; set; }
        public string Query { get; set; }
        public string SourceObject { get; set; }
        public short BatchSize { get; set; }

        public Guid ProcessId { get; set; }
    }
}
