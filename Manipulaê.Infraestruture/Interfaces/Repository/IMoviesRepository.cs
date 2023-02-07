using Manipulaê.Infraestruture.Model.Entities;
using Manipulaê.Infraestruture.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulaê.Infraestruture.Interfaces.Repository
{
    public  interface IMoviesRepository
    {
        Task<string> AddExternalVideos(List<MoviesEntities> movies);
        Task<List<MoviesEntities>> AllMovies();
        Task<MoviesEntities> MovieById(Guid Id);
        Task<MoviesEntities> InsertMovies(MoviesEntities movies);
        Task<MoviesEntities> UpdateMovies(MoviesEntities movies);
        Task DeleteMovies(Guid Id);
    }
}
