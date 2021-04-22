﻿using System;
using ContentGuide.ViewModels;
using Xamarin.Forms;

namespace ContentGuide.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel(Navigation);
        }
    }
}
