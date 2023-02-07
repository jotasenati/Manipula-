using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulaê.Infraestruture.Model.Entities
{
    public class MoviesEntities
    {
        public Guid? Id { get; set; }
        public string Kind { get; set; }
        public string Etag { get; set; }
        public string VideoId { get; set; }
        public string KindId { get; set; }
        public bool IsEnable { get; set; }
    }
}
