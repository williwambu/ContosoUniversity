using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ContosoUniversity.Models; 
namespace ContosoUniversity.DAL
{
    public class SchoolContext : DbContext
    {
        //students 
        public DbSet<Student> Students { get; set; }
        
        //Enrollments
        public DbSet<Enrollment> Enrollments { get; set; }

        //Courses
        public DbSet<Course> Courses { get; set; }

        //Departments   
        public DbSet<Department> Departments { get; set; }

        //OfficeAssignments
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        //Instructors
        public DbSet<Instructor> Instructors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Fluent API to map the many to many r/ship
             modelBuilder.Entity<Course>().HasMany(c => c.Instructors).WithMany(i => i.Courses)
                 .Map(t => t.MapLeftKey("CourseID")
                 .MapRightKey("InstructorID")
                 .ToTable("CourseInstructor"));
        }
   }
}