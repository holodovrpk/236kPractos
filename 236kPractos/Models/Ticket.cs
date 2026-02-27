using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236kPractos.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int HallId { get; set; }
        public Hall Hall { get; set; }

        public decimal? Price { get; set; }
        public DateTime? date { get; set; }
        public int? Place {  get; set; }
        public int? Row {  get; set; }
    }
}
