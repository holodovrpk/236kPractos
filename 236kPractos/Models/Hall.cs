using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236kPractos.Models
{
    public class Hall
    {
        public int HallId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int Rows { get; set; }
        public int Places { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
