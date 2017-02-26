using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastleClashdb.Models.CastleClash
{
    public class Evolved
    {
        public int Id { get; set; }
        public string Evo { get; set; } // will be generic evo1 evo2

        public ICollection<Hero> Hero { get; set; }
    }
}
