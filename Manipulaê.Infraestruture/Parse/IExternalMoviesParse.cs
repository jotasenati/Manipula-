using Manipulaê.Infraestruture.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulaê.Infraestruture.Parse
{
    public interface IExternalMoviesParse
    {
        Task<string> ParseMovies(List<MoviesDTO> movies);
    }
}
