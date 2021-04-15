using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ContentGuide.Services;
using ContentGuide.Views;
using Xamarin.Essentials;

namespace ContentGuide
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            //MainPage =new NavigationPage(new AddGenre());
        }

        public void navigationMain(string to)
        {
            switch (to)
            {
                case "login":
                    MainPage = new NavigationPage(new LoginPage()) { BarBackgroundColor = ColorConverters.FromHex("#397367"), BarTextColor = Color.White };
                    break;
                case "signup":
                    MainPage = new NavigationPage(new SignUpPage()) { BarBackgroundColor = ColorConverters.FromHex("#397367"), BarTextColor = Color.White };
                    break;
                case "main":
                    MainPage = new NavigationPage(new HomePage());
                    break;
                case "list":
                    MainPage = new NavigationPage(new GenresPage());
                    break;
            }
        }

        protected override void OnStart()
        {
            var isLoggedIn = App.Current.Properties.ContainsKey("username") && App.Current.Properties.ContainsKey("password");
            Console.WriteLine(isLoggedIn);
            if (!isLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage()) { BarBackgroundColor = ColorConverters.FromHex("#397367"), BarTextColor = Color.White };
            }
            else
            {
                MainPage = new NavigationPage(new HomePage());
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            var isLoggedIn = App.Current.Properties.ContainsKey("username") && App.Current.Properties.ContainsKey("password");
            Console.WriteLine(isLoggedIn);
            if (!isLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage()) { BarBackgroundColor = ColorConverters.FromHex("#397367"), BarTextColor = Color.White };
            }
            else
            {
                MainPage = new NavigationPage(new HomePage());
            }
        }
    }
}
