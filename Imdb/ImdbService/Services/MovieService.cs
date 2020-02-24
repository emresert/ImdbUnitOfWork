using ImdbData.Contexts;
using ImdbData.Models;
using ImdbData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ImdbData.UnitOfWork;

namespace ImdbService.Services
{
    public class MovieService 
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public int GenerateMovieId(Movie obj)
        {
            Movie movieForInsert = new Movie();
            movieForInsert.movieLink = obj.movieLink;
            movieForInsert.movieName = obj.movieName;
            movieForInsert.movieYear = obj.movieYear;
            movieForInsert.movieImageUrl = obj.movieImageUrl;
            //var movieRepository = new MovieRepository();
            //movieRepository.Insert(movieForInsert);
            unitOfWork.MovieRepository.Insert(movieForInsert);
            unitOfWork.Save();
            
           
            return movieForInsert.movieId;

        }
        public bool deleteMovie(Movie movie)
        {
            //var movieRepository = new MovieRepository();
            //movieRepository.Delete(movie);
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.MovieRepository.Delete(movie);
                unitOfWork.Save();
            }
            
            return true;
        }
        
        public Movie FindMovie(string _link)
        {
            //Movie selectedMovie = new Movie();
            //var movieRepository = new MovieRepository();
  
            return unitOfWork.MovieRepository.FindWithLink(x => x.movieLink == _link);
        }

        
       
    }
}
