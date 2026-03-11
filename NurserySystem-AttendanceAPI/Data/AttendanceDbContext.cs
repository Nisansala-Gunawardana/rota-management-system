using Microsoft.EntityFrameworkCore;
using NurserySystem_AttendanceAPI.Model;

namespace NurserySystem_AttendanceAPI.Data
{
    public class AttendanceDbContext:DbContext
    {
        public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options):base(options)
        {
            
        }

        public DbSet<EmpShiftDetails> EmpShiftDetails { get; set; }
        public DbSet<RotaDetails> RotaDetails { get; set; }
      public DbSet<RoomDetails> RoomDetails { get; set; }
        public DbSet<BreakTimes> BreakTimes { get; set; }
        public DbSet<EmpAbsentDetails> EmpAbsentDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmpShiftDetails>()
                .HasIndex(e => new { e.EMPId, e.WorkingDay })
                .IsUnique();

            modelBuilder.Entity<RotaDetails>()
                .HasIndex(r => new { r.EmpId, r.WeekSdate, r.WorkDate })
                .IsUnique();

            modelBuilder.Entity<EmpAbsentDetails>()
                .HasIndex(a => new { a.EmpId, a.AbsentDate })
                .IsUnique();
        }
    }

    
}
