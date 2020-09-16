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
    public partial class TextWithLabel : ContentView
    {





        #region BindableProperties


        public static readonly BindableProperty IconProperty = BindableProperty.Create(
                                                                                            propertyName: nameof(Icon),
                                                                                            returnType: typeof(string),
                                                                                            declaringType: typeof(TextWithLabel)
                                                                                        );

        public string Icon
        {
            get
            {
                return (string)GetValue(IconProperty);
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }




        public static readonly BindableProperty IconColorProperty = BindableProperty.Create(
                                                                                            propertyName: nameof(IconColor),
                                                                                            returnType: typeof(Color),
                                                                                            declaringType: typeof(TextWithLabel)
                                                                                            );

        public Color IconColor
        {
            get
            {
                return (Color)GetValue(IconColorProperty);
            }
            set
            {
                SetValue(IconColorProperty, value);
            }
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
                                                                                              propertyName: nameof(Title),
                                                                                              returnType: typeof(string),
                                                                                              declaringType: typeof(TextWithLabel),
                                                                                              defaultValue: "Default"
                                                                                              );
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }



        public static readonly BindableProperty TitleColorProperty = BindableProperty.Create(
                                                                                              propertyName: nameof(TitleColor),
                                                                                              returnType: typeof(Color),
                                                                                              declaringType: typeof(TextWithLabel)
                                                                                              );

        public Color TitleColor
        {
            get
            {
                return (Color)GetValue(TitleColorProperty);
            }
            set
            {
                SetValue(TitleColorProperty, value);
            }
        }




        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
                                                                                              propertyName: nameof(Value),
                                                                                              returnType: typeof(string),
                                                                                              declaringType: typeof(TextWithLabel)
                                                                                              );

        public string Value
        {
            get
            {
                return (string)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }




        public static readonly BindableProperty ValueColorProperty = BindableProperty.Create(
                                                                                              propertyName: nameof(ValueColor),
                                                                                              returnType: typeof(Color),
                                                                                              declaringType: typeof(TextWithLabel)
                                                                                              );

        public Color ValueColor
        {
            get
            {
                return (Color)GetValue(ValueColorProperty);
            }
            set
            {
                SetValue(ValueColorProperty, value);
            }
        }






        #endregion

        public TextWithLabel()
        {
            InitializeComponent();
        }
    }
}