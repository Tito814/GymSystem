using GymSystem.Config;
using GymSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GymSystem
{
    public class GymAppContext : DbContext
    {
        public GymAppContext(DbContextOptions<GymAppContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlanConfiguration());
        }
        public DbSet<Plan> Plans { get; set; }
    }
}
