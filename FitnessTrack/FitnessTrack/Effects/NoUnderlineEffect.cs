using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessTrack.Effects
{
    public class NoUnderlineEffect : RoutingEffect
    {
        public NoUnderlineEffect() : base($"FitnessTrack.{nameof(NoUnderlineEffect)}")
        {
        }
    }
}
