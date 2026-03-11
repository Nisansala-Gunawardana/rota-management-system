using Microsoft.EntityFrameworkCore;
using NurserySystem_HRWebAPI.Model;

namespace NurserySystem_HRWebAPI.Data
{
    public class HRDbContext : DbContext
    {
        public HRDbContext(DbContextOptions<HRDbContext> options):base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ContractDetails> ContractDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ContractDetails>()
                .HasIndex(c => new { c.EmpId, c.CStatus })
                .IsUnique()
                .HasFilter("[CStatus]= 1");
        }
    }
}
