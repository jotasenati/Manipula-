using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulaê.Infraestruture.NewFolder
{
    public  class MoviesDTO
    {
        public string Kind { get; set; }
        public string Etag { get; set; }
        public Id Id { get; set; }
        public string menssage { get; set; }
    }

    public class Id
    {
        public string Kind { get; set; }
        public string VideoId { get; set; }
    }
}
