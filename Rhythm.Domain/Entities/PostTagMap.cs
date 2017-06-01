using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhythm.Domain.Entities
{
    public class PostTagMap
    {
        public int PostTagMapId { get; set; }
        public int TagId { get; set; }
        public int PostId { get; set; }
    }
}
