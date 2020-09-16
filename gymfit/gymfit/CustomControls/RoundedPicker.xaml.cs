using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymFit.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoundedPicker : Frame
    {
        #region Bindable Propeties
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

        public static BindableProperty ItemsProperty = BindableProperty.Create(
                                                                                propertyName: nameof(Items),
                                                                                returnType: typeof(IList),
                                                                                declaringType: typeof(RoundedEntry),
                                                                                propertyChanged: OnItemsChange,
                                                                                defaultBindingMode: BindingMode.TwoWay
                                                                                );
        public static BindableProperty TitleProperty = BindableProperty.Create(
                                                                                propertyName: nameof(Title),
                                                                                returnType: typeof(string),
                                                                                declaringType: typeof(RoundedEntry),
                                                                                propertyChanged: OnTitleChanged,
                                                                                defaultBindingMode: BindingMode.TwoWay
                                                                                );
        public static BindableProperty SelectedItemProperty = BindableProperty.Create(
                                                                                propertyName: nameof(SelectedItem),
                                                                                returnType: typeof(object),
                                                                                declaringType: typeof(RoundedEntry),
                                                                                defaultBindingMode: BindingMode.TwoWay
                                                                                );



        #endregion

        #region Properties

        public object SelectedItem
        {
            get
            {
                return GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }
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
        public IList Items
        {
            get
            {
                return (IList)GetValue(ItemsProperty);
            }
            set
            {
                SetValue(ItemsProperty, value);
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

        #endregion

        private Color _previusBackgroundColor;

        public RoundedPicker()
        {
            InitializeComponent();
            
        }

        private static void OnTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RoundedPicker)bindable;
            if(control != null)
            {
                control.picker.Title = (string)newValue;
            }
        }

        private static void OnItemsChange(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RoundedPicker)bindable;
            if(control != null)
            {
                control.picker.ItemsSource = (IList)newValue;
            }
        }
        private static void OnInnerBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RoundedPicker)bindable;
            if(control != null)
            {
                control.innerFrame.BackgroundColor = (Color)newValue;
            }
        }

        private void picker_Focused(object sender, FocusEventArgs e)
        {
            _previusBackgroundColor = this.BackgroundColor;
            this.BackgroundColor = FocusedColor;
        }

        private void picker_Unfocused(object sender, FocusEventArgs e)
        {
            if (_previusBackgroundColor != null)
                this.BackgroundColor = _previusBackgroundColor;
        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = this.picker.SelectedIndex;
            this.SelectedItem = this.picker.ItemsSource[index];
        }
    }
}