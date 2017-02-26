using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CastleClashdb.Models.CastleClash
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Hero> Hero { get; set; }
    }
}
