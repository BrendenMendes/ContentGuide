using System;
using System.Collections.Generic;
using ContentGuide.Models;

namespace ContentGuide.Services
{
    public class GenreService
    {
        List<GenreModel> genreModelList = new List<GenreModel>();
        public List<string> vs = new List<string>() { "Action", "Animation", "Comedy", "Crime", "Drama", "English", "Fantasy", "Historical", "Horror", "Romance", "Science", "Fiction", "Thriller" };

        public GenreService()
        {
            foreach (var item in vs)
            {
                GenreModel model = new GenreModel();
                model.genreName = item;
                genreModelList.Add(model);
            }

        }

        public List<GenreModel> GetGenres()
        {
            return genreModelList;
        }
    }
}
