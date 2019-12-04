using System;

namespace DIT.Domain.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}