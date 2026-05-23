using GymSystem.Config;
using GymSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GymSystem
{
    public class GymAppContext : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GymDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlanConfiguration());
        }
        public DbSet<Plan> Plans { get; set; }
    }
}
