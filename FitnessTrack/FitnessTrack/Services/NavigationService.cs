using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessTrack.Services
{

    public interface INavigationService
    {
        Task DisplayAlertAsync(string title, string message, string ok);
        Task<string> DisplayPromptAndGetResponseAysnc(string title, string message, string accept, string cancel, string placeholder, int maxLenght, Keyboard keyboard);
        
    }

    public class NavigationService : INavigationService
    {
        public async Task DisplayAlertAsync(string title, string message, string ok)
        {
            await App.Current.MainPage.DisplayAlert(title, message, ok);
        }

        public async Task<string> DisplayPromptAndGetResponseAysnc(string title, string message, string accept, string cancel, string placeholder, int maxLenght, Keyboard keyboard)
        {
            return await App.Current.MainPage.DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLenght, keyboard);
        }
    }
}
