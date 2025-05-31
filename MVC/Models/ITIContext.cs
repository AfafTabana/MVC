using Microsoft.EntityFrameworkCore;
using System;

namespace MVC.Models
{
    public class ITIContext : DbContext
    {

        public DbSet<Department> Departments { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Trainee> Trainees { get; set; }

        public DbSet<crsResult> CourseResult { get; set; }

        public ITIContext() {
        
        } 

        public ITIContext(DbContextOptions<ITIContext> options) :base(options)
        {

        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NE1FOI0; Initial Catalog=MyITI;Integrated Security=True;Encrypt=false;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
