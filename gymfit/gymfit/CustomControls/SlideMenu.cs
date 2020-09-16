using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GymFit.CustomControls
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class SlideMenu : ContentView
    {

        private int _numberItems;
        private List<Label> _labels;
        private int _selectedIndex;
        private Frame _transparentSelector;
        private Frame _selector;

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            propertyName: nameof(ItemsSource),
            returnType: typeof(string[]),
            declaringType: typeof(SlideMenu),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnItemsChanged);




        public static readonly BindableProperty SelectedStartIndexProperty = BindableProperty.Create(
            propertyName: nameof(SelectedStartIndex),
            returnType: typeof(int),
            declaringType: typeof(SlideMenu),
            defaultValue: 0);


        public static readonly BindableProperty SelectedTextColorProperty = BindableProperty.Create(
            propertyName: nameof(SelectedTextColor),
            returnType: typeof(Color),
            declaringType: typeof(SlideMenu),
            defaultValue: Color.White);


        public static readonly BindableProperty UnselectedTextColorProperty = BindableProperty.Create(
            propertyName: nameof(UnselectedTextColor),
            returnType: typeof(Color),
            declaringType: typeof(SlideMenu),
            defaultValue: Color.Black);



        public static readonly BindableProperty SelectorColorProperty = BindableProperty.Create(
            propertyName: nameof(SelectorColor),
            returnType: typeof(Color),
            declaringType: typeof(SlideMenu),
            defaultValue: Color.Purple);

        public static readonly BindableProperty SelectionChangedCommandProperty = BindableProperty.Create(
            propertyName: nameof(SelectionChangedCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(SlideMenu));

        public ICommand SelectionChangedCommand
        {
            get
            {
                return (ICommand)GetValue(SelectionChangedCommandProperty);
            }
            set
            {
                SetValue(SelectionChangedCommandProperty, value);
            }
        }

        public Color SelectorColor
        {
            get
            {
                return (Color)GetValue(SelectorColorProperty);
            }
            set
            {
                SetValue(SelectorColorProperty, value);
            }
        }

        public Color UnselectedTextColor
        {
            get
            {
                return (Color)GetValue(UnselectedTextColorProperty);
            }
            set
            {
                SetValue(UnselectedTextColorProperty, value);
            }
        }

        public Color SelectedTextColor
        {
            get
            {
                return (Color)GetValue(SelectedTextColorProperty);
            }
            set
            {
                SetValue(SelectedTextColorProperty, value);
            }
        }

        public int SelectedStartIndex
        {
            get
            {
                return (int)GetValue(SelectedStartIndexProperty);
            }
            set
            {
                SetValue(SelectedStartIndexProperty, value);
            }
        }

        public string[] ItemsSource
        {
            get
            {
                return (string[])GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public ICommand ItemTapped { get; set; }



        public SlideMenu()
        {
            _labels = new List<Label>();
            ItemTapped = new Command<int>((newIndex) => OnSelectedIndexChanged(newIndex));
            InitializeComponents();
        }

        private void OnSelectedIndexChanged(int newIndex)
        {
            SetLabelColor(_selectedIndex, UnselectedTextColor);
            SetLabelColor(newIndex, SelectedTextColor);
            _selectedIndex = newIndex;
            _ = MoveSelectorToCurrentItem();
            NotifySelectionChanged();
        }

        private void NotifySelectionChanged()
        {
            if (SelectionChangedCommand != null && SelectionChangedCommand.CanExecute(_selectedIndex))
            {
                SelectionChangedCommand.Execute(_selectedIndex);
            }
        }

        private void SetLabelColor(int labelIndex, Color color)
        {
            _labels[labelIndex].TextColor = color;
        }

        private async Task MoveSelectorToCurrentItem()
        {
            Grid.SetColumn(_transparentSelector, _selectedIndex);
            await _selector.TranslateTo(_transparentSelector.X - _selector.X, 0, 300, Easing.SinInOut);
            Grid.SetColumn(_selector, _selectedIndex);
            _selector.TranslationX = 0;
        }

        public void InitializeComponents()
        {
            
            if (ItemsSource != null)
            {
                _numberItems = ItemsSource.Count();
                _selectedIndex = SelectedStartIndex;
                var grid = GetGrid();
                AddSelector(grid);
                AddLabelsToGrid(grid);

                this.Content = grid;
            }
        }

        private void AddSelector(Grid grid)
        {
            _selector = new Frame()
            {
                BackgroundColor = SelectorColor,
                CornerRadius = 10,
                HasShadow = false
            };
            _transparentSelector = new Frame()
            {
                BackgroundColor = Color.Transparent
            };
            grid.Children.Add(_transparentSelector);
            grid.Children.Add(_selector);
            Grid.SetColumn(_selector, _selectedIndex);
            Grid.SetColumn(_transparentSelector, _selectedIndex);
        }

        private void AddLabelsToGrid(Grid grid)
        {
            var itemsSourceList = ItemsSource.ToList();
            for (int i = 0; i < _numberItems; i++)
            {
                var label = new Label()
                {
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    Text = itemsSourceList[i],
                    TextColor = i == _selectedIndex ? SelectedTextColor : UnselectedTextColor,
                    GestureRecognizers = { new TapGestureRecognizer(){ Command = ItemTapped, CommandParameter = i }}
                };
                _labels.Add(label);
                grid.Children.Add(label);
                Grid.SetColumn(label, i);

            }
        }

        private Grid GetGrid()
        {
            var grid = new Grid()
            {
                HeightRequest = 50
            };
            var columnsDefinitions = new ColumnDefinitionCollection();
            for (int i = 0; i < _numberItems; i++)
            {
                columnsDefinitions.Add(new ColumnDefinition() {Width = GridLength.Star});
            }

            grid.ColumnDefinitions = columnsDefinitions;
            grid.RowDefinitions = new RowDefinitionCollection()
            {
                new RowDefinition(){ Height = new GridLength(50)}
            };
            return grid;
        }

        private static void OnItemsChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var slideMenu = bindable as SlideMenu;
            if (slideMenu != null)
            {
                slideMenu.InitializeComponents();
            }
        }
    }
}