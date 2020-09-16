using System.Threading.Tasks;
using Xamarin.Forms;

namespace GymFit.Services.Interfaces
{
	public interface IPageService
	{
		Task PushAsync(Page page);
		Task<Page> PopAsync();

		Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
		Task DisplayAlert(string title, string message, string ok);

		Task PopToRootPage();

		Task PopPagesAsync(int numOfPages);

		Task<string> DisplayPromptAsync(string question, string message, string initialValue, Keyboard keyboardType);
		Task<string> DisplayActionSheet(string message, string cancelButton, params string[] buttons);
	}
}
