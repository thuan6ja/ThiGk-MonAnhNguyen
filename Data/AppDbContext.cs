using Microsoft.EntityFrameworkCore;
using NhuThuan_K2023_THIGK.Entity;
using System;

namespace NhuThuan_K2023_THIGK.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<CourseEntity> Course { get; set; }
        public DbSet<EnrollmentEntity> Enrollment { get; set; }

        // Quan hệ 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CourseEntity>()
                 .HasMany(c => c.Enrollments)
                 .WithOne(e => e.Course)
                 .HasForeignKey(e => e.CourseId)
                 .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

        }
    }
}