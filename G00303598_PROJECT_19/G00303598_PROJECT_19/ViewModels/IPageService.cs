using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

/*
 * IPageService is an interface that represents services a page can provide
 */
namespace G00303598_PROJECT_19
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task<bool> DisplayAlertAsync(string title, string message, string ok, string cancel);
    }
}
