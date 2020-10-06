using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FitnessTrack.Controls
{
    public class FullListView : ContentView
    {

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            propertyName: nameof(ItemsSource),
            returnType: typeof(ObservableCollection<object>),
            declaringType: typeof(FullListView),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnItemsSourceChanged
        );

        public ObservableCollection<object> ItemsSource
        {
            get
            {
                return (ObservableCollection<object>)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(
            propertyName: nameof(ItemTemplate),
            returnType: typeof(DataTemplate),
            declaringType: typeof(FullListView),
            defaultBindingMode: BindingMode.TwoWay
        );

        public DataTemplate ItemTemplate
        {
            get
            {
                return (DataTemplate)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public Grid Grid { get; set; }

        public FullListView()
        {
            Grid = new Grid();
            Content = Grid;
            ItemsSource = new ObservableCollection<object>();
            ItemsSource.CollectionChanged += OnItemSourceAddedOrRemoved;
            Initialize();
        }

        private void Initialize()
        {
            if(ItemsSource != null && ItemsSource.Count > 0)
            {
                ConfigureGrid();
                AddSourceToGrid();
            }
        }


        private void ConfigureGrid()
        {
            var rowDefinitions = new RowDefinitionCollection();
            var columnDefinitions = new ColumnDefinitionCollection()
            {
                new ColumnDefinition(){ Width = GridLength.Star }
            };
            for (int i = 0; i < ItemsSource.Count; i++)
            {
                rowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            }
            Grid.RowDefinitions = rowDefinitions;
            Grid.ColumnDefinitions = columnDefinitions;
        }
        private void AddSourceToGrid()
        {
            foreach(var item in ItemsSource)
            {
                Grid.Children.Add(GetRowView(item));
            }
        }

        private View GetRowView(object item)
        {
            if(ItemTemplate is DataTemplateSelector dts)
            {
                var template = dts.SelectTemplate(item, this);
                return (View)template.CreateContent();
            }
            return null;
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var collection = (ObservableCollection<object>)newValue;
            var previusCollection = (ObservableCollection<object>)oldValue;
            if(previusCollection != null)
                previusCollection.CollectionChanged -= OnItemSourceAddedOrRemoved;
            if(collection != null)
                collection.CollectionChanged += OnItemSourceAddedOrRemoved;

        }

        private static void OnItemSourceAddedOrRemoved(object sender, NotifyCollectionChangedEventArgs e)
        {
            
        }
    }
}