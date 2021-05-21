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
        }

        public void navigationMain(string to)
        {
            switch (to)
            {
                case "login":
                    MainPage = new NavigationPage(new LoginPage());
                    break;
                case "signup":
                    MainPage = new NavigationPage(new SignUpPage());
                    break;
                case "genre":
                    MainPage = new NavigationPage(new GenresPage());
                    break;
                case "home":
                    MainPage = new NavigationPage(new HomePage());
                    break;
                case "details":
                    MainPage = new NavigationPage(new DetailsPage());
                    break;
            }
        }

        protected override void OnStart()
        {
            var isLoggedIn = App.Current.Properties.ContainsKey("username") && App.Current.Properties.ContainsKey("password");
            Console.WriteLine(isLoggedIn);
            if (!isLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
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
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new HomePage());
            }
        }
    }
}
