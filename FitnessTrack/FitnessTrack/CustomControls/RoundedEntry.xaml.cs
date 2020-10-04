using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessTrack.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoundedEntry : ContentView
    {


        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            propertyName: nameof(Placeholder),
            returnType: typeof(string),
            declaringType: typeof(RoundedEntry),
            defaultValue: default(string)
        );

        public string Placeholder
        {
            get
            {
                return (string)GetValue(PlaceholderProperty);
            }
            set
            {
                SetValue(PlaceholderProperty, value);
            }
        }


        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
            propertyName: nameof(CornerRadius),
            returnType: typeof(int),
            declaringType: typeof(RoundedEntry),
            defaultValue: default(int)
        );
            
        public int CornerRadius
        {
            get
            {
                return (int)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }


        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(RoundedEntry),
            defaultValue: default(string),
            defaultBindingMode: BindingMode.TwoWay
        );

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }


        public static readonly BindableProperty EntryBackgroundColorProperty = BindableProperty.Create(
            propertyName: nameof(EntryBackgroundColor),
            returnType: typeof(Color),
            declaringType: typeof(RoundedEntry),
            defaultValue: Color.White
        );

        public Color EntryBackgroundColor
        {
            get
            {
                return (Color)GetValue(EntryBackgroundColorProperty);
            }
            set
            {
                SetValue(EntryBackgroundColorProperty, value);
            }
        }



        public RoundedEntry()
        {
            InitializeComponent();
        }
    }
}