using Microsoft.EntityFrameworkCore;

namespace AssesementWebAPI.Domain.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=SAKTHI;Database=TestContactDB;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
