using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistence
{
    public class AppDbContext: DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentAddress> StudentsAddresses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses  { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options ): base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");
                entity.HasKey(e => e.StudentId);
                entity.Property(t => t.StudentId).ValueGeneratedOnAdd();
                entity.HasOne<StudentAddress>(s => s.Address)
                .WithOne(ad => ad.Student)
                .HasForeignKey<StudentAddress>(ad => ad.AddressOfStudentId);

            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);
                entity.Property(e => e.CourseId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<StudentAddress>(entity =>
            {
                entity.HasKey(e => e.StudentAddressId);
                entity.Property(e => e.StudentAddressId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new {sc.StudentId, sc.CourseId });

                entity.HasOne<Student>(sc => sc.Student)
                    .WithMany(s => s.StudentCourses)
                    .HasForeignKey(sc => sc.StudentId);

                entity.HasOne<Course>(sc => sc.Course)
                    .WithMany(s => s.StudentCourses)
                    .HasForeignKey(sc => sc.CourseId);
            });

                
        }
    }
}
