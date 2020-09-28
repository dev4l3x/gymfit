﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessTrack.Views.Routines
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExercisesView : ContentView
    {
        public AddExercisesView()
        {
            InitializeComponent();
        }

        private void SearchBar_Focused(object sender, FocusEventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new SearchExercisePage());
        }
    }
}