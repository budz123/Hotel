using Microsoft.EntityFrameworkCore;

namespace ManageStaffDBApp.Model.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-HCFHTED\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security = True");
        }
    }
}
