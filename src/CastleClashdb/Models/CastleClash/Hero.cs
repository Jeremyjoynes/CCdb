using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CastleClashdb.Models.CastleClash
{
    public class Hero 
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int level { get; set; }

      public int  CategoryId { get; set; }
      public Category Category { get; set; }
                                           //public ICollection<AlterHeroes> AlterHeroes { get; set; }

    }
}
