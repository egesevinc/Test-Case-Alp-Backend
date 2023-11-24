using CaseAlp.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseAlp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

     
        public ApplicationDbContext() { }

      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer("Server=localhost;Database=appDatabase;Trusted_Connection=True;");
    }

}
