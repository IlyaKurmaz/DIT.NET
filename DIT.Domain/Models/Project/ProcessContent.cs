using DIT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIT.Domain.Models
{
    public sealed class ProcessContent: IEntity
    {
        public Guid Id { get; set; }
    }
}
