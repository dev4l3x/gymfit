using System.Collections.Generic;
using FitnessTrack.Domain.Base;

namespace FitnessTrack.Domain
{
    public class Routine : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int Days { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
    }
}
