using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulaê.Infraestruture.Model.Requests
{
    public  class MoviesInsert
    {
        public Guid Id { get; set; }
        public string Kind { get; set; }
        public string Etag { get; set; }
        public string KindId { get; set; }
        public string VideoId { get; set; }
    }
}
