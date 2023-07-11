using ConsultancyApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class Agencies:BaseEntity
    {
        public string  Name  { get; set; }
        public string   Url  { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public string About { get; set; }
        public string City { get; set; }
        public int FoundationYear { get; set; }

        public int CategoryId { get; set; }
        public List<Category> Category { get; set; }
        public List<Lesson> Lessons { get; set; }
        public int LessonId { get; set; }


        public List<CategoriesLessons> CategoriesLessons  { get; set; }
    }
}
