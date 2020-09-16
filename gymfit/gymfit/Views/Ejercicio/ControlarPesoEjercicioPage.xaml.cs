using GymFit.ViewModels.Ejercicio;
using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymFit.Views.Ejercicio
{
    using Helpers;
    using Models;
    using Syncfusion.DataSource;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlarPesoEjercicioPage : ContentPage
    {
        public ControlarPesoEjercicioPage(Models.Ejercicio ejercicio)
        {
            InitializeComponent();

            ViewModel = App.kernel.Get<ControlarPesoEjercicioViewModel>(new ConstructorArgument("ejercicio", ejercicio));

            Registros.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "IndexDay",
                KeySelector = (obj) =>
                {
                    var registro = obj as Registro;
                    if (registro != null)
                    {
                        return registro.Serie;
                    }

                    return 0;
                },
                Comparer = new CustomGroupComparer()
            });
        }

        public ControlarPesoEjercicioViewModel ViewModel
        {
            get
            {
                return BindingContext as ControlarPesoEjercicioViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }

    }

}