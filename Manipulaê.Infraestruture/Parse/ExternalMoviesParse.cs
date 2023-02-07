using Manipulaê.Infraestruture.Interfaces.Repository;
using Manipulaê.Infraestruture.Model.Entities;
using Manipulaê.Infraestruture.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Manipulaê.Infraestruture.Parse
{
    public class ExternalMoviesParse : IExternalMoviesParse
    {
        private readonly IMoviesRepository _moviesRepository;
        public ExternalMoviesParse(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        public async Task<string> ParseMovies(List<MoviesDTO> movies)
        {
            var lista = new List<MoviesEntities>();

            foreach (var i in movies)
            {
                var item = new MoviesEntities();

                item.IsEnable = true;
                item.Id = Guid.NewGuid();
                item.KindId = i.Id.Kind;
                item.VideoId = i.Id.VideoId;
                item.Kind = i.Kind;
                item.Etag = i.Etag;

                lista.Add(item);
            }

            return await _moviesRepository.AddExternalVideos(lista);
        }
    }
}
