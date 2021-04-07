using System;
using System.Collections.Generic;
using System.Linq;
using ContentGuide.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContentGuide.Views
{
    public partial class GenresPage : ContentPage
    {
        List<String> selectedGenre = new List<String>();

        public GenresPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (selectedGenre.Count() == 0)
            {
                DisplayAlert("Alert!", "No Genre Selected", "dismiss");
                return;
            }

            String selectedGenreString = String.Join(",", selectedGenre);
            Preferences.Set("selectedGenre", selectedGenreString);
            Navigation.PushAsync(new GenresPage());
        }

        private void Action_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Action");
            }
            else
            {
                selectedGenre.Remove("Action");
            }
        }
        private void Animation_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Animation");
            }
            else
            {
                selectedGenre.Remove("Animation");
            }
        }
        private void Adventure_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Adventure");
            }
            else
            {
                selectedGenre.Remove("Adventure");
            }
        }
        private void Biography_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Biography");
            }
            else
            {
                selectedGenre.Remove("Biography");
            }
        }
        private void Costume_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Costume");
            }
            else
            {
                selectedGenre.Remove("Costume");
            }
        }
        private void Comedy_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Comedy");
            }
            else
            {
                selectedGenre.Remove("Comedy");
            }
        }
        private void Romance_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Romance");
            }
            else
            {
                selectedGenre.Remove("Romance");
            }
        }
        private void Horror_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Horror");
            }
            else
            {
                selectedGenre.Remove("Horror");
            }
        }
        private void Scifi_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Scifi");
            }
            else
            {
                selectedGenre.Remove("Scifi");
            }
        }
        private void Documentary_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Documentary");
            }
            else
            {
                selectedGenre.Remove("Documentary");
            }
        }

        private void Crime_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Crime");
            }
            else
            {
                selectedGenre.Remove("Crime");
            }
        }
        private void Drama_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Drama");
            }
            else
            {
                selectedGenre.Remove("Drama");
            }
        }
        private void Family_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Family");
            }
            else
            {
                selectedGenre.Remove("Family");
            }
        }
        private void Fantasy_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Fantasy");
            }
            else
            {
                selectedGenre.Remove("Fantasy");
            }
        }
        private void Gameshow_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Game-show");
            }
            else
            {
                selectedGenre.Remove("Game-show");
            }
        }
        private void History_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("History");
            }
            else
            {
                selectedGenre.Remove("History");
            }
        }
        private void Kungfu_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Kungfu");
            }
            else
            {
                selectedGenre.Remove("Kungfu");
            }
        }
        private void Music_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Music");
            }
            else
            {
                selectedGenre.Remove("Music");
            }
        }
        private void Sports_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Sports");
            }
            else
            {
                selectedGenre.Remove("Sports");
            }
        }
        private void Thriller_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Thriller");
            }
            else
            {
                selectedGenre.Remove("Thriller");
            }
        }
    }
}
