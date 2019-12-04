using DIT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIT.Domain.Models.User
{
    public sealed class User : IEntity
    {
        public Guid Id { get; set; }

    }
}
