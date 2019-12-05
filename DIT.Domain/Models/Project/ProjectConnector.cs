using DIT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIT.Domain.Models
{
    public class ProjectConnector : IEntity
    {
        public Guid Id { get; set; }

        public Connector Connector { get; set; }

        public Project Project { get; set; }
    }
}
