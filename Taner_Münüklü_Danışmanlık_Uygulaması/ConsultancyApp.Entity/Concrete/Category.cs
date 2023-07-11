using ConsultancyApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string About { get; set; }



        public List<Agencies> Agencies { get; set; }
        public int AgenciesId { get; set; }
        public List<CategoriesLessons> CategoriesLessons { get; set; }

    }
}
