using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastleClashdb.Models.CastleClash
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Talent { get; set; }
        public int TalentLevel { get; set; }
        public int Inscription { get; set; }
    }
}
