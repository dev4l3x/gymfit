using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.Models
{
    using System.Numerics;
    using Newtonsoft.Json;

    public abstract class Entity
    {
        [JsonProperty("id")]
        public BigInteger Id { get; set; }
    }
}
