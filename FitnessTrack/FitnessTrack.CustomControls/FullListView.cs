﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FitnessTrack.Controls
{
    public class FullListView : ContentView
    {

        private DataTemplate _template;

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
                return (DataTemplate)GetValue(ItemTemplateProperty);
            }
            set
            {
                SetValue(ItemTemplateProperty, value);
            }
        }

        public Grid Grid { get; set; }

        public FullListView()
        {
            Grid = new Grid();
            Content = Grid;
            Initialize();
        }

        private void Initialize()
        {
            if(ItemsSource != null)
            {
                CreateDataTemplate();
                ConfigureGrid();
                AddSourceToGrid();
            }
        }

        private void CreateDataTemplate()
        {
            _template = new DataTemplate(() => {
                var frame = new Frame { HasShadow = false, CornerRadius = 10, HeightRequest = 60, Padding = 10 };
                var stackLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
                var entry = new Entry() { Keyboard = Keyboard.Numeric, WidthRequest = 30, MaxLength = 2 };
                var label = new Label() { Text = "repeticiones", VerticalTextAlignment = TextAlignment.Center };
                stackLayout.Children.Add(entry);
                stackLayout.Children.Add(label);
                frame.Content = stackLayout;
                return frame;
            });
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
            for (int i = 0; i < ItemsSource.Count; i++)
            {
                var view = GetRowView(ItemsSource[i]);
                Grid.SetRow(view, i);
                Grid.Children.Add(view);
            }
        }

        private View GetRowView(object item)
        {
            var view = (View)_template.CreateContent();
            view.BindingContext = item;
            return view;
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var list = (bindable as FullListView);
            list?.SubscribeForItemsChanged();
            list?.Initialize();
        }

        private void SubscribeForItemsChanged()
        {
            if(ItemsSource != null)
            {
                ItemsSource.CollectionChanged += OnItemSourceAddedOrRemoved;
            }
        }

        private async void OnItemSourceAddedOrRemoved(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach(var item in e.NewItems)
                {
                    Grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    var view = GetRowView(item);
                    view.Scale = 0;
                    Grid.SetRow(view, ItemsSource.Count - 1);
                    Grid.Children.Add(view);
                    this.InvalidateMeasure();
                    view.ScaleTo(1, 500, Easing.SinInOut);
                }
            }
            else if(e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.NewItems)
                {
                    Grid.RowDefinitions.Remove(Grid.RowDefinitions.Last());
                    var viewsToRemove = Grid.Children.Where((view) => view.BindingContext == item);
                    foreach (var view in viewsToRemove)
                    {
                        await view.ScaleTo(0, 500, Easing.SinInOut);
                        Grid.Children.Remove(view);
                        this.InvalidateMeasure();
                    }
                }
            }
        }
    }
}