using System;
using System.Collections.ObjectModel;
using ContentGuide.Services;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace ContentGuide.ViewModels
{
    public class HomeViewModel
    {
        public ObservableCollection<Trending> Trendings { get; set; } = new ObservableCollection<Trending>();
        public ObservableCollection<Movies> Movies { get; set; } = new ObservableCollection<Movies>();
        public ObservableCollection<TVshows> Tvshows { get; set; } = new ObservableCollection<TVshows>();

        NetworkCalls networkCalls = new NetworkCalls();
        string token = App.Current.Properties["token"] as string;

        public HomeViewModel()
        {
            trending();
            movies();
            tvshows();
        }

        public void trending()
        {
            string trendingJson = networkCalls.Trending(token);
            var trending = JsonConvert.DeserializeObject<Trending[]>(trendingJson);

            Trendings.Clear();

            foreach (var item in trending)
            {
                Trendings.Add(item);
            }
        }

        public void movies()
        {
            string moviesJson = networkCalls.Movies(token);
            var movies = JsonConvert.DeserializeObject<Movies[]>(moviesJson);

            Movies.Clear();

            foreach (var item in movies)
            {
                Movies.Add(item);
            }
        }

        public void tvshows()
        {
            string tvshowsJson = networkCalls.TVshows(token);
            var tvshows = JsonConvert.DeserializeObject<TVshows[]>(tvshowsJson);

            Tvshows.Clear();

            foreach (var item in tvshows)
            {
                Tvshows.Add(item);
            }
        }
    }
}
