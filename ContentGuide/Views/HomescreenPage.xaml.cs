using System;
using System.Collections.Generic;
using ContentGuide.ViewModels;
using Xamarin.Forms;

namespace ContentGuide.Views
{
    public partial class HomescreenPage : ContentPage
    {
        private App app = Application.Current as App;
        public HomescreenPage()
        {
            InitializeComponent();
            BindingContext = new GenresViewModel();

        }

        private void logout(object sender, EventArgs e)
        {
            App.Current.Properties["isLoggedIn"] = false;
            app.navigationMain("login");
        }
    }
}
