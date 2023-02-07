using AutoMapper;
using Manipulaê.Infraestruture.Interfaces;
using Manipulaê.Infraestruture.Interfaces.Repository;
using Manipulaê.Infraestruture.Model.Entities;
using Manipulaê.Infraestruture.Model.Requests;
using Manipulaê.Infraestruture.NewFolder;
using Manipulaê.Infraestruture.Parse;
using Manipulaê.Infraestruture.Utils.Enum;
using Manipulaê.Infraestruture.Utils.Menssage;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Manipulaê.Infraestruture.ExternalServices
{
    public class YoutubeApi : IYoutubeApi
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IExternalMoviesParse _externalMoviesParse;

        public YoutubeApi(IMoviesRepository moviesRepository, IExternalMoviesParse externalMoviesParse)
        {
            _moviesRepository = moviesRepository;
            _externalMoviesParse = externalMoviesParse;
        }

        public async Task<List<MoviesDTO>> YoutubeSearch(string parametro, bool insertOnDb)
        {
            var apiKey = "AIzaSyAaX9REV7jSSEDFBcdOImpuDPyehu4UX4c";
            var youtubeApiUrl = $"https://youtube.googleapis.com/youtube/v3/search?={parametro}&maxResults={((int)Enums.Pagination)}&key={apiKey}";

            using var client = new HttpClient();
            var response = await client.GetAsync(youtubeApiUrl);

            if (!response.IsSuccessStatusCode)
            {
                return new List<MoviesDTO>();
            }

            var json = await response.Content.ReadAsStringAsync();

            var jo = JObject.Parse(json);
            var movies = jo["items"].ToObject<MoviesDTO[]>();

            if (insertOnDb)
            {

                var result = await _externalMoviesParse.ParseMovies(movies.ToList());

                return new List<MoviesDTO>()
                {
                    new MoviesDTO
                    {
                        menssage = result
                    }
                };
            }
            else
            {
                return movies.ToList();

            }
        }
    }
}
