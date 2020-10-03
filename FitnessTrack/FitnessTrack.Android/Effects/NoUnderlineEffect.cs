using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Widget;
using FitnessTrack.Droid.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ResolutionGroupName("FitnessTrack")]
[assembly: ExportEffect(typeof(NoUnderlineEffect), nameof(NoUnderlineEffect))]
namespace FitnessTrack.Droid.Effects
{
    public class NoUnderlineEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if(Control != null && Control is SearchView)
            {
                var plateId = Control.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
                var plate = Control.FindViewById(plateId);
                plate.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
            else if(Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }

        protected override void OnDetached()
        {

        }
    }
}
