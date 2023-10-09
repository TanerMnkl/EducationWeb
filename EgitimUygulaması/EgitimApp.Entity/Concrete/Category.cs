using EgitimApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Entity.Concrete
{
    public class Category:BaseEntity
    {

        public string Name { get; set; }
        public string About { get; set; }
        public string Url { get; set; }
        public List<CoursesCategories>CoursesCategories { get; set; }
    }
}
