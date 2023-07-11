using ConsultancyApp.Data.Concrete.EfCore.Configs;
using ConsultancyApp.Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Concrete.EfCore.Contexts
{
    public class ConsultancyAppContext :DbContext
    {
       
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Agencies> Agencies { get; set; }
        
        public DbSet<CategoriesLessons>  CategoriesLessons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            optionsBuilder.UseSqlite("Data Source=ConsultancyApp.db");
            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LessonConfig).Assembly);
            base.OnModelCreating(modelBuilder); 
        }




    }
}
