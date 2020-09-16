using System;
using System.Collections.Generic;
using System.Text;

namespace GymFit.ViewModels.Ejercicio
{
    public class RegistroViewModel : BaseViewModel
    {

        private string _numero;
        private string _peso;
        private string _rir;

        public string Rir
        {
            get
            {
                return _rir;
            }
            set
            {
                _rir = value;
                OnPropertyChanged();
            }
        }
        public string Peso
        {
            get
            {
                return _peso;
            }
            set
            {
                _peso = value;
                OnPropertyChanged();
            }
        }
        public string Numero
        {
            get
            {
                return _numero;
            }
            set
            {
                _numero = value;
                OnPropertyChanged();
            }
        }


    }
}
