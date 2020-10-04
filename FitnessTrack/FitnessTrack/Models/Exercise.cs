using FitnessTrack.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FitnessTrack.Models
{
    public class Exercise : Entity
    {
        private string SetsWithReps { get; set; }
        public ExerciseSpecification Specification { get; set; }
        [NotMapped]
        public List<int> Sets
        {
            get
            {
                var sets = new List<int>();
                if(!string.IsNullOrWhiteSpace(SetsWithReps))
                {
                    var reps = SetsWithReps.Split('-');
                    foreach(var stringRep in reps)
                    {
                        sets.Add(int.Parse(stringRep));
                    }
                }
                return sets;
            }
            set
            {
                SetsWithReps = string.Join("-", value);
            }
        }
        public Routine Routine { get; set; }
        public int Day { get; set; }

        [NotMapped]
        public string SetsString
        {
            get
            {
                return SetsWithReps;
            }
        }
    }

    public class ExerciseSpecification : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
