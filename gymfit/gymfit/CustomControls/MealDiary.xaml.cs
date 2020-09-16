using GymFit.Models;
using GymFit.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymFit.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealDiary : Frame
    {

        #region BindableProperties

        public static BindableProperty TitleProperty = BindableProperty.Create(
                                                                          propertyName: nameof(Title),
                                                                          returnType: typeof(string),
                                                                          declaringType: typeof(MealDiary),
                                                                          defaultValue: "Title",
                                                                          defaultBindingMode: BindingMode.TwoWay
                                                                        );

        public static BindableProperty AlimentosProperty = BindableProperty.Create(
                                                                          propertyName: nameof(Alimentos),
                                                                          returnType: typeof(ObservableCollection<Alimento>),
                                                                          declaringType: typeof(MealDiary),
                                                                          defaultValue: new ObservableCollection<Alimento>(),
                                                                          propertyChanged: OnAlimentosPropertyChanged,
                                                                          defaultBindingMode: BindingMode.TwoWay
                                                                        );


        public static readonly BindableProperty CaloriesProperty = BindableProperty.Create(
                                                                          propertyName: nameof(Calories),
                                                                          returnType: typeof(string),
                                                                          declaringType: typeof(MealDiary),
                                                                          defaultBindingMode: BindingMode.OneWay
                                                                       
                                                                        );

        

        public static BindableProperty AddCommandProperty = BindableProperty.Create(
                                                                          propertyName: nameof(AddCommand),
                                                                          returnType: typeof(ICommand),
                                                                          declaringType: typeof(MealDiary),
                                                                          defaultBindingMode: BindingMode.TwoWay
                                                                        );

        public static BindableProperty DeleteCommandProperty = BindableProperty.Create(
                                                                          propertyName: nameof(DeleteCommand),
                                                                          returnType: typeof(ICommand),
                                                                          declaringType: typeof(MealDiary),
                                                                          defaultBindingMode: BindingMode.TwoWay
                                                                        );

        #endregion

        public ICommand AddCommand
        {
            get
            {
                return (ICommand)GetValue(AddCommandProperty);
            }
            set
            {
                SetValue(AddCommandProperty, value);
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return (ICommand)GetValue(DeleteCommandProperty);
            }
            set
            {
                SetValue(DeleteCommandProperty, value);
            }
        }

        
        public string Calories
        {
            get
            {
                return (string)GetValue(CaloriesProperty);
            }
            set
            {
                SetValue(CaloriesProperty, value);
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
        public ObservableCollection<Alimento> Alimentos
        {
            get
            {
                return (ObservableCollection<Alimento>)GetValue(AlimentosProperty);
            }
            set
            {
                SetValue(AlimentosProperty, value);
            }
        }
        public MealDiary()
        {
            InitializeComponent();


        }

        #region Events


        private static void OnAlimentosPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MealDiary)bindable;
            if(control != null)
            {
                var collection = (ObservableCollection<Alimento>)newValue;
                collection.CollectionChanged += control.ResizeList;
                control.listView.ItemsSource = collection;
            }
        }

        private void ResizeList(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.listView.HeightRequest = this.listView.RowHeight * ((ObservableCollection<Alimento>)listView.ItemsSource).Count();
        }

        private static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            DeleteCommand?.Execute(((MenuItem)sender).CommandParameter);
        }
        #endregion
    }
}