using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessTrack.Domain.Base
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
