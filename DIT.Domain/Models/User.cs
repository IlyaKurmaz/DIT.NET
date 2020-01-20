using DIT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DIT.Domain.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<Connector> Connectors { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

    }
}