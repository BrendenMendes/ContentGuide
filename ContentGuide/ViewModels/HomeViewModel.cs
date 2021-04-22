using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ContentGuide.Services;
using ContentGuide.Views;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContentGuide.ViewModels
{
    public class HomeViewModel
    {
        public INavigation Navigation { get; set; }
        private App app = Application.Current as App;
        public string username;
        public ObservableCollection<Trending> Trendings { get; set; } = new ObservableCollection<Trending>();
        public ObservableCollection<Movies> Movies { get; set; } = new ObservableCollection<Movies>();
        public ObservableCollection<TVshows> Tvshows { get; set; } = new ObservableCollection<TVshows>();

        NetworkCalls networkCalls = new NetworkCalls();

        string token = App.Current.Properties["token"] as string;

        public HomeViewModel(INavigation navigation)
        {
            Username = App.Current.Properties["name"] as string;
            trending();
            movies();
            tvshows();
            this.Navigation = navigation;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public void trending()
        {
            string trendingJson = networkCalls.Trending(token);
            var trending = JsonConvert.DeserializeObject<Trending[]>(trendingJson);

            Trendings.Clear();

            foreach (var item in trending)
            {
                item.TapClickEventHandler = selectedTrending;
                Trendings.Add(item);
            }
        }

        public void movies()
        {
            string preferences = Preferences.Get("selectedGenre", "");
            string moviesJson = networkCalls.Movies(token, preferences);
            var movies = JsonConvert.DeserializeObject<Movies[]>(moviesJson);

            Movies.Clear();

            foreach (var item in movies)
            {
                item.TapClickEventHandler = selectedMovie;
                Movies.Add(item);
            }
        }

        public void tvshows()
        {
            string preferences = Preferences.Get("selectedGenre", "");
            string tvshowsJson = networkCalls.TVshows(token, preferences);
            var tvshows = JsonConvert.DeserializeObject<TVshows[]>(tvshowsJson);

            Tvshows.Clear();

            foreach (var item in tvshows)
            {
                item.TapClickEventHandler = selectedTvshow;
                Tvshows.Add(item);
            }
        }

        private async void selectedTrending(Object sender, EventArgs e)
        {
            var param = (Trending)sender;
            Console.WriteLine("Tapped "+param.Title);
            detailsAsync(param.Title);
        }

        private void selectedMovie(Object sender, EventArgs e)
        {
            var param = (Movies)sender;
            Console.WriteLine("Tapped " + param.Title);
            detailsAsync(param.Title);
        }

        private void selectedTvshow(Object sender, EventArgs e)
        {
            var param = (TVshows)sender;
            Console.WriteLine("Tapped " + param.Title);
            detailsAsync(param.Title);
        }

        private async void detailsAsync(string title)
        {
            Application.Current.Properties["selection"] = title;
            await Application.Current.SavePropertiesAsync();
            new DetailsViewModel();
            Navigation.PushAsync(new DetailsPage());
        }
    }
}
