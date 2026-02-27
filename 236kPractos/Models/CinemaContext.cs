using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236kPractos.Models
{
    public class CinemaContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=NEXTOUCH313\SQLEXPRESS;Database=CinemaBD;
                    Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public CinemaContext()
        {
            Database.EnsureCreated();
        }


    }
}
