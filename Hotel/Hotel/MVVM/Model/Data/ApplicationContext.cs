using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.MVVM.Model.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Clients> clients { get; set; }
        public DbSet<Rooms> rooms { get; set; }
        public DbSet<Reservations> reservations { get; set; }
        public ApplicationContext()
        {
           
        }
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HCFHTED\SQLEXPRESS;Initial Catalog=TermPaper;Integrated Security=True");

        }
    }
}
