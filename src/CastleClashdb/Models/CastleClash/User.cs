using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CastleClashdb.Models.CastleClash
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<AlterHeroes> AlterHeroes { get; set; }
    }
}
