using FitnessTrack.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTrack.Models
{
    public class Exercise : Entity
    {
        public ExerciseSpecification Specification { get; set; }
        public List<int> Sets { get; set; }
    }

    public class ExerciseSpecification
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
