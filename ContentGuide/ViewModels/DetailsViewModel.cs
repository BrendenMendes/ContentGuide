using System;
using System.Collections.ObjectModel;
using ContentGuide.Services;
using ContentGuide.Singleton;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace ContentGuide.ViewModels
{
    public class DetailsViewModel
    {
        string trailer = string.Empty;
        string title = string.Empty;
        string rated = string.Empty;
        string released = string.Empty;
        string runtime = string.Empty;
        string director = string.Empty;
        string writer = string.Empty;
        string actors = string.Empty;
        string plot = string.Empty;
        string language = string.Empty;
        string awards = string.Empty;
        string imdbrating = string.Empty;
        string imdbvotes = string.Empty;
        string boxOffice = string.Empty;
        string production = string.Empty;

        public ObservableCollection<Details> ContentDetails { get; set; } = new ObservableCollection<Details>();

        NetworkCalls networkCalls = new NetworkCalls();

        public DetailsViewModel()
        {
            string token = App.Current.Properties["token"] as string;
            string selection = App.Current.Properties["selection"] as string;

            string detailsJson = networkCalls.ContentDetails(token, selection);
            var detail = JsonConvert.DeserializeObject<Details>(detailsJson);
            Console.WriteLine(detail.Trailer);
            Trailer = detail.Trailer;
            Title = detail.Title;
            Rated = detail.Rated;
            Plot = detail.Plot;
            Released = detail.Released;
            Runtime = detail.Runtime;
            imdbRating = detail.imdbRatings;
            imdbVotes = detail.imdbVotes;
            Language = detail.Language;
            Actors = detail.Actors;
            Director = detail.Director;
            Writer = detail.Writer;
            Production = detail.Production;
            Awards = detail.Awards;
            BoxOffice = detail.BoxOffice;
        }

        public string Trailer
        {
            get { return trailer; }
            set { trailer = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Rated
        {
            get { return rated; }
            set { rated = value; }
        }

        public string Plot
        {
            get { return plot; }
            set { plot = value; }
        }

        public string Released
        {
            get { return released; }
            set { released = value; }
        }

        public string Runtime
        {
            get { return runtime; }
            set { runtime = value; }
        }

        public string imdbRating
        {
            get { return imdbrating; }
            set { imdbrating = value; }
        }

        public string imdbVotes
        {
            get { return imdbvotes; }
            set { imdbvotes = value; }
        }

        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        public string Actors
        {
            get { return actors; }
            set { actors = value; }
        }

        public string Director
        {
            get { return director; }
            set { director = value; }
        }

        public string Writer
        {
            get { return writer; }
            set { writer = value; }
        }

        public string Production
        {
            get { return production; }
            set { production = value; }
        }

        public string Awards
        {
            get { return awards; }
            set { awards = value; }
        }

        public string BoxOffice
        {
            get { return boxOffice; }
            set { boxOffice = value; }
        }
    }
}
