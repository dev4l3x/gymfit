using GymFit.ViewModels.Ejercicio;
using GymFit.ViewModels.Rutinas;
using GymFit.Views.Ejercicio;
using Ninject;
using Syncfusion.ListView.XForms;
using Syncfusion.XForms.TabView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymFit.Views.Rutinas
{
    using Helpers;
    using Models;
    using Syncfusion.DataSource;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRutinaPage : ContentPage
    {

        private int _selectedSwipeIndex;
        public TabItemCollection TabItems { get; set; }

        public AddRutinaPage()
        {
            InitializeComponent();
            ViewModel = App.kernel.Get<AddRutinaViewModel>();
            TabItems = new TabItemCollection();

            MessagingCenter.Subscribe<AddRutinaViewModel>(this, Events.ChangeFirstTabOnAddRutina, (sender) => tabView.SelectedIndex = 0);

            Exercises.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "IndexDay",
                KeySelector = (obj) =>
                {
                    var ejercicio = obj as Ejercicio;
                    if (ejercicio != null)
                    {
                        return ejercicio.IndexDay;
                    }

                    return 0;
                },
                Comparer = new CustomGroupComparer()
            });
            //tabbedView.Items = TabItems;
        }


        public AddRutinaViewModel ViewModel
        {
            get
            {
                return BindingContext as AddRutinaViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }

        private void SfListView_SwipeStarted(object sender, Syncfusion.ListView.XForms.SwipeStartedEventArgs e)
        {
            _selectedSwipeIndex = e.ItemIndex;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ViewModel.DeleteEjercicioCommand.Execute(_selectedSwipeIndex);
        }

    }
}