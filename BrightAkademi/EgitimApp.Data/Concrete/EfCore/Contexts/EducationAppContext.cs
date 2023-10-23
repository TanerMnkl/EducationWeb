using EgitimApp.Data.Concrete.EfCore.Configs;
using EgitimApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Data.Concrete.EfCore.Contexts
{
    public class EducationAppContext :DbContext
    {
        public EducationAppContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CoursesCategories> CoursesCategories { get; set; }
        public DbSet<CoursesTrainees> CoursesTrainees { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Settings> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
