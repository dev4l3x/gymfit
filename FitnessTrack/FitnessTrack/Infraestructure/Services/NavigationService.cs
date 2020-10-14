using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTrack.Domain;
using Xamarin.Forms;

namespace FitnessTrack.Infraestructure.Services
{

    public interface INavigationService
    {
        Task PopAsync();
        Task PopAsync(int pagesToPop);
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

        public async Task PopAsync()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task PopAsync(int pagesToPop)
        {
            var numPagesToRemove = pagesToPop - 1;
            var pagesToRemove = new List<Page>();
            var pages = App.Current.MainPage.Navigation.NavigationStack.ToArray();
            for (int i = numPagesToRemove; i > 0; i--)
            {
                App.Current.MainPage.Navigation.RemovePage(pages[pages.Length - 1 - i]);
            }
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
