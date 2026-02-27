using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236kPractos.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string? Rejiser { get; set; }
        public int? Duration { get; set; }
        public int? Year { get; set; }
        [MaxLength(50)]
        public string? Genre { get; set; }
        [MaxLength(50)]
        public string? Country { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
