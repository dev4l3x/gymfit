using GymFit.Models;
using GymFit.ViewModels.Rutinas;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Parameters;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GymFit.Views.Ejercicio;
using Syncfusion.ListView.XForms;
using Syncfusion.XForms.TabView;

namespace GymFit.Views.Rutinas
{
    using Helpers;
    using Syncfusion.DataSource;
    using Ejercicio = Models.Ejercicio;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleRutinaPage : ContentPage
    {

        public TabItemCollection TabItems { get; set; }
        public DetalleRutinaPage(Rutina rutina)
        {
            InitializeComponent();
            ViewModel = App.kernel.Get<DetalleRutinaViewModel>(new ConstructorArgument("rutina", rutina));
            TabItems = new TabItemCollection();

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
        }

        public DetalleRutinaViewModel ViewModel
        {
            get
            {
                return BindingContext as DetalleRutinaViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }

        private SfListView CreateListViewForEjercicios(int index)
        {
            var numDias = ViewModel.RutinaActual.NumDiasSemana;
            var listaEjercicios = numDias == 0 || index >= numDias
                ? new List<Models.Ejercicio>()
                : ViewModel.RutinaActual.Ejercicios.Where((ejercicio) => ejercicio.IndexDay == index);
            var content = new SfListView()
            {
                ItemsSource = listaEjercicios,
                AutoFitMode = AutoFitMode.DynamicHeight,
                IsScrollingEnabled = true,
                ItemSize = 100,
                SelectionBackgroundColor = Color.Transparent,
                AllowSwiping = true,
                SelectionMode = Syncfusion.ListView.XForms.SelectionMode.SingleDeselect,
                SelectionChangedCommand = ViewModel.ControlarPesoEjercicioCommand
            };
            

            content.ItemTemplate = new DataTemplate(() =>
            {
                return new ListaEjercicios();
            });


            return content;
        }
    }
}