using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FitnessTrack.Domain.Base;

namespace FitnessTrack.Domain
{
    public class Exercise : Entity
    {
        private string SetsWithReps { get; set; }
        public ExerciseSpecification Specification { get; set; }
        [NotMapped]
        public List<Set> Sets
        {
            get
            {
                var sets = new List<Set>();
                if(!string.IsNullOrWhiteSpace(SetsWithReps))
                {
                    var reps = SetsWithReps.Split('-');
                    foreach(var stringRep in reps)
                    {
                        sets.Add(new Set { Reps = int.Parse(stringRep) });
                    }
                }
                return sets;
            }
            set
            {
                var sets = new List<int>();
                value.ForEach((set) => sets.Add(set.Reps));
                SetsWithReps = string.Join("-", sets);
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
