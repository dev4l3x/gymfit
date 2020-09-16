using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymFit.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoundedDatePicker : Frame
    {
        #region BindableProperties

        public static BindableProperty InnerBackgroundColorProperty = BindableProperty.Create(
                                                                                propertyName: nameof(InnerBackgroundColor),
                                                                                returnType: typeof(Color),
                                                                                declaringType: typeof(RoundedEntry),
                                                                                defaultValue: default(Color),
                                                                                propertyChanged: OnInnerBackgroundColorChanged,
                                                                                defaultBindingMode: BindingMode.TwoWay
                                                                                );


        public static BindableProperty FocusedColorProperty = BindableProperty.Create(
                                                                                propertyName: nameof(FocusedColor),
                                                                                returnType: typeof(Color),
                                                                                declaringType: typeof(RoundedEntry),
                                                                                defaultBindingMode: BindingMode.TwoWay
                                                                                );


        #endregion

        private Color _previousBackgroundColor;

        #region Properties
       

        public Color FocusedColor
        {
            get
            {
                return (Color)GetValue(FocusedColorProperty);
            }
            set
            {
                SetValue(FocusedColorProperty, value);
            }
        }


        public Color InnerBackgroundColor
        {
            get
            {
                return (Color)GetValue(InnerBackgroundColorProperty);
            }
            set
            {
                SetValue(InnerBackgroundColorProperty, value);
            }
        }



        #endregion
        public RoundedDatePicker()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private static void OnInnerBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RoundedDatePicker)bindable;
            if(control != null)
            {
                control.innerFrame.BackgroundColor = (Color)newValue;
            }
        }

        private void datepicker_Focused(object sender, FocusEventArgs e)
        {
            _previousBackgroundColor = this.BackgroundColor;
            this.BackgroundColor = this.FocusedColor;
        }

        private void datepicker_Unfocused(object sender, FocusEventArgs e)
        {
            if(_previousBackgroundColor != null)
            {
                this.BackgroundColor = _previousBackgroundColor;
            }
        }
    }
}