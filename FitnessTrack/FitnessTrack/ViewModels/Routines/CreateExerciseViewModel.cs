using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTrack.ViewModels.Routines
{
    public class CreateExerciseViewModel: BaseViewModel
    {

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }


        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyPropertyChanged();
            }
        }









    }
}
