using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ContentGuide.Models;
using ContentGuide.Services;
using ContentGuide.Singleton;
using Xamarin.Forms;

namespace ContentGuide.ViewModels
{
    public class GenresViewModel : BaseViewModel
    {
        public ObservableCollection<String> _vs = new ObservableCollection<String>();
        public ObservableCollection<String> vs
        {
            get { return _vs; }
            set { SetProperty(ref _vs, value); }
        }


        public List<GenreModel> models { get; set; }
        GenreService service = new GenreService();
        public ICommand clickChanged { get; set; }
        public GenresViewModel()
        {
            Title = "Add Genre";
            vs.Add("No Genre Selected");
            models = service.GetGenres();
            clickChanged = new Command((obj) =>
            {
                var button = obj as Button;

                if (vs.Contains(button.Text))
                {
                    vs.Remove(button.Text);
                }
                else
                {
                    vs.Add(button.Text);
                }
                if (vs.Count == 0)
                {
                    vs.Add("No Genre Selected");
                }
                else
                {
                    vs.Remove("No Genre Selected");
                }
            });
        }
    }
}
