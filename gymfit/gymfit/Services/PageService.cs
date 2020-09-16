using GymFit.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GymFit.Services
{
	public class PageService : IPageService
	{
		public async Task DisplayAlert(string title, string message, string ok)
		{
			await MainPage.DisplayAlert(title, message, ok);
		}

		public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
		{
			return await MainPage.DisplayAlert(title, message, ok, cancel);
		}

		public async Task PushAsync(Page page)
		{
			await MainPage.Navigation.PushAsync(page);
		}

		public async Task<Page> PopAsync()
		{
			
			return await MainPage.Navigation.PopAsync();
		}

		private Page MainPage
		{
			get { return Application.Current.MainPage; }
		}

		public async Task PopToRootPage()
		{
			await MainPage.Navigation.PopToRootAsync();
		}

		public async Task PopPagesAsync(int numOfPages)
		{
			Page[] pagesToDeleteExceptLast = new Page[numOfPages - 1];
			var navigationStack = this.MainPage.Navigation.NavigationStack;
			if (numOfPages > navigationStack.Count)
			{
				return;
			}

			var lastIndex = navigationStack.Count - 2;
			for(int i = 0; i < numOfPages - 1 ; i++)
			{
				pagesToDeleteExceptLast[i] = navigationStack[lastIndex - i];
			}

			pagesToDeleteExceptLast.ToList().ForEach((page) => this.MainPage.Navigation.RemovePage(page));
			await MainPage.Navigation.PopAsync();
		}

		public async Task<string> DisplayPromptAsync(string question, string message, string initialValue, Keyboard keyboardType)
		{
			return await MainPage.DisplayPromptAsync(question, message, "Ok", "Cancelar", initialValue, keyboard: keyboardType);
		}

		public async Task<string> DisplayActionSheet(string message, string cancelButton, params string[] buttons)
		{
			return await MainPage.DisplayActionSheet(message, cancelButton, null, buttons);
		}
	}
}
