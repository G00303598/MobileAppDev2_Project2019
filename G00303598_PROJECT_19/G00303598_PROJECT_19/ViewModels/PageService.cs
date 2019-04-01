using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace G00303598_PROJECT_19.ViewModels
{
    public class PageService : IPageService
    {
        #region Async Methods
        public async Task<bool> DisplayAlertAsync(string title, string message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
        #endregion
    }
}
