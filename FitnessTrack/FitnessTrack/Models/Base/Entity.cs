﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrack.Models.Base
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
