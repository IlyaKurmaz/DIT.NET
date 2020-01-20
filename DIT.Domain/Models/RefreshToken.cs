using DIT.Domain.Enums;
using DIT.Domain.Interfaces;
using System;

namespace DIT.Domain
{
    public class RefreshToken : IEntity
    {
        public Guid Id { get; set; }

        public string Token { get; set; }

        public RefreshTokenStatus Status { get; set; }

    }
}