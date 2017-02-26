using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CastleClashdb.Models.CastleClash
{
    public class AlterHeroes
    {
        
        public int HeroId { get; set; }
        public Hero hero { get; set; }
       
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
