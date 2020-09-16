using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymFit.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoundedEntry : Frame
    {

        #region BindableProperties

        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(RoundedEntry), "Default", propertyChanged: OnPlaceholderPropertyChanged);
        public static BindableProperty PlaceholderColorProperty = BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(RoundedEntry), Color.White, propertyChanged: OnPlaceholderColorPropertyChanged, defaultBindingMode: BindingMode.TwoWay);
        public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(RoundedEntry), Color.White, propertyChanged: OnTextColorPropertyChanged, defaultBindingMode: BindingMode.TwoWay);
        public static BindableProperty IsPasswordProperty = BindableProperty.Create(
                                                                                               propertyName: nameof(IsPassword), 
                                                                                               returnType: typeof(bool), 
                                                                                               declaringType: typeof(RoundedEntry), 
                                                                                               defaultValue: false, 
                                                                                               propertyChanged: OnIsPasswordPropertyChanged, 
                                                                                               defaultBindingMode: BindingMode.TwoWay
                                                                                             );

        public static BindableProperty TextProperty = BindableProperty.Create(
                                                                                propertyName: nameof(Text),
                                                                                returnType: typeof(string),
                                                                                declaringType: typeof(RoundedEntry),
                                                                                defaultValue: default(string),
                                                                                propertyChanged: OnTextPropertyChanged,
                                                                                defaultBindingMode: BindingMode.TwoWay
                                                                                );

        public static BindableProperty InnerBackgroundColorProperty = BindableProperty.Create(
                                                                                propertyName: nameof(InnerBackgroundColor),
                                                                                returnType: typeof(Color),
                                                                                declaringType: typeof(RoundedEntry),
                                                                                defaultValue: default(Color),
                                                                                propertyChanged: OnInnerBackgroundColorChanged,
                                                                                defaultBindingMode: BindingMode.TwoWay
                                                                                );

        public static BindableProperty KeyboardProperty = BindableProperty.Create(
                                                                                propertyName: nameof(Keyboard),
                                                                                returnType: typeof(Keyboard),
                                                                                declaringType: typeof(RoundedEntry),
                                                                                defaultValue: default(Keyboard),
                                                                                propertyChanged: OnKeyboardChanged,
                                                                                defaultBindingMode: BindingMode.TwoWay
                                                                                );

        public static BindableProperty FocusedColorProperty = BindableProperty.Create(
                                                                                propertyName: nameof(FocusedColor),
                                                                                returnType: typeof(Color),
                                                                                declaringType: typeof(RoundedEntry),
                                                                                defaultBindingMode: BindingMode.TwoWay
                                                                                );





        #endregion

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

        public Keyboard Keyboard
        {
            get
            {
                return (Keyboard)GetValue(KeyboardProperty);
            }
            set
            {
                SetValue(KeyboardProperty, value);
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

        public bool IsPassword
        {
            get
            {
                return (bool)GetValue(IsPasswordProperty);
            }
            set
            {
                SetValue(IsPasswordProperty, value);
            }
        }
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

        public Color PlaceholderColor
        {
            get
            {
                return (Color)GetValue(PlaceholderColorProperty);
            }
            set
            {
                SetValue(PlaceholderColorProperty, value);
            }
        }

        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }

            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        #endregion


        public RoundedEntry()
        {
            InitializeComponent();
            _previousBackgroundColor = BackgroundColor;
            
        }

        private Color _previousBackgroundColor;


        #region Events
        private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RoundedEntry)bindable;
            if(control != null)
            {
                control.entry.Text = (string)newValue;
            }
        }
        private static void OnKeyboardChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RoundedEntry)bindable;
            if(control != null)
            {
                control.entry.Keyboard = (Keyboard)newValue;
            }
        }
        private static void OnInnerBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RoundedEntry)bindable;
            if(control != null)
            {
                control.innerFrame.BackgroundColor = (Color)newValue;
               
            }
        }
        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            if(this.FocusedColor != null)
            {
            }
        }
        public static void OnPlaceholderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RoundedEntry)bindable;
            if(control != null)
            {
                control.entry.Placeholder = newValue as string;
            }
        }
        private static void OnPlaceholderColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RoundedEntry)bindable;
            if(control != null)
            {
                control.entry.PlaceholderColor = (Color) newValue;
            }
        }
        private static void OnTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RoundedEntry)bindable;
            if(control != null)
            {
                control.entry.TextColor = (Color) newValue;
            }
        }
        private static void OnIsPasswordPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RoundedEntry)bindable;
            if(bindable != null)
            {
                control.entry.IsPassword = (bool)newValue;
            }
        }

        private void entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Text = e.NewTextValue;
            
        }

        private void entry_Unfocused(object sender, FocusEventArgs e)
        {
        }

        #endregion
    }
}