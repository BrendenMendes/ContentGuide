using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContentGuide.Singleton
{
    public class Nav
    {
        private App app = Application.Current as App;
        public Nav()
        {
        }

        public Task DisplayAlertAsync(string title, string message, string button = "Ok")
        {
            return app.MainPage.DisplayAlert(title, message, button);
        }

        public static Nav Shared = new Nav();
    }
}
