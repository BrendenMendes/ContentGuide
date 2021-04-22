using System;
using System.ComponentModel;
using ContentGuide.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContentGuide.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }
    }
}
