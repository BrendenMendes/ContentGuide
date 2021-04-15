using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using ContentGuide.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ContentGuide.Views
{
    public partial class HomePage : ContentPage
    {
        //private readonly HttpClient httpClient = new HttpClient();

        //public ObservableCollection<Trending> Trendings { get; set; } = new ObservableCollection<Trending>(); 

        HomeViewModel home = new HomeViewModel();

        public HomePage()
        {
            InitializeComponent();

            //BindingContext = this;
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    var trendingJson = await httpClient.GetStringAsync(monkeyURL);
        //    //client.DefaultRequestHeaders.Add("X-Version", "1");
        //    Console.WriteLine(trendingJson);
        //    var trending = JsonConvert.DeserializeObject<Trending[]>(trendingJson);

        //    Trendings.Clear();

        //    foreach(var item in trending)
        //    {
        //        Trendings.Add(item);
        //    }
        //} 

        //private void TrendingViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{

        //}
    }
}
