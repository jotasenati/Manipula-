using Manipulaê.Infraestruture.Interfaces.Repository;
using Manipulaê.Infraestruture.Model.Context;
using Manipulaê.Infraestruture.Model.Entities;
using Manipulaê.Infraestruture.Model.Requests;
using Manipulaê.Infraestruture.Utils.Menssage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulaê.Infraestruture.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MoviesContext _context;

        public MoviesRepository(MoviesContext context)
        {
            _context = context;
        }

        public async Task<string> AddExternalVideos(List<MoviesEntities> movies)
        {
            try
            {
                var result = _context.Movies.AddRangeAsync(movies);
                await _context.SaveChangesAsync();

                return Menssages.Sucesso;
            }
            catch (Exception)
            {
                return Menssages.Erro;
            }
            

        }

        public async Task<List<MoviesEntities>> AllMovies()
        {
            return await _context.Movies.Where(x => x.IsEnable).ToListAsync();
        }

        public async Task DeleteMovies(Guid Id)
        {
            var movie = await _context.Movies.FindAsync(Id);
            movie.IsEnable = false;
            var result = _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<MoviesEntities> InsertMovies(MoviesEntities movies)
        {
            movies.Id = Guid.NewGuid();
            movies.IsEnable = true;

            var result = _context.Movies.AddAsync(movies);
            _context.SaveChangesAsync();

            return movies;
        }

        public async Task<MoviesEntities> MovieById(Guid Id)
        {
            return await _context.Movies.FindAsync(Id);

        }

        public async Task<MoviesEntities> UpdateMovies(MoviesEntities movies)
        {
            var result = _context.Entry(movies).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return movies;
        }
    }
}
