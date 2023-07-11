using ConsultancyApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public   class Lesson :BaseEntity
    {
        public string Name { get; set; }
        public string About { get; set; }
        public string Url { get; set; }
        public int AgenciesId { get; set; }
        public Agencies Agency { get; set; }
        public string ImageUrl { get; set; }

        public List<CategoriesLessons> CategoriesLessons { get; set; }
        public decimal Price { get; set; }
        public int Kontenjan { get; set; }
        public string PeriodOfStudy { get; set; }

       





    }
}
