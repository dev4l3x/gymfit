using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FitnessTrack.CustomControls
{
    public class NumericInput : ContentView
    {

        public static readonly BindableProperty MaxNumberProperty = BindableProperty.Create(
            propertyName: nameof(MaxNumber),
            returnType: typeof(int),
            declaringType: typeof(NumericInput),
            defaultValue: 100,
            BindingMode.TwoWay
        );

        public int MaxNumber
        {
            get
            {
                return (int)GetValue(MaxNumberProperty);
            }
            set
            {
                SetValue(MaxNumberProperty, value);
            }
        }

        public NumericInput()
        {
            var stack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };



            Content = stack;
        }

        private View GetPlusControlView()
        {
            var skView = new SKCanvasView();
            skView.PaintSurface += OnPaintSurface;


            return skView;
        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var surfaceInfo = e.Info;
            var canvas = e.Surface.Canvas;

            canvas.Clear();
            //canvas.DrawCircle(0, 0, 20, new SkiaSharp.SKPaint { Color =  })
        }

        private View GetMinusControlView()
        {
            var skView = new SKCanvasView();

            return skView;
        }
    }
}