using Manipulaê.Infraestruture.Model.Requests;
using Manipulaê.Infraestruture.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulaê.Infraestruture.Interfaces
{
    public  interface IYoutubeApi
    {
        Task<List<MoviesDTO>> YoutubeSearch(string parametro, bool insertOnDb);
    }
}
