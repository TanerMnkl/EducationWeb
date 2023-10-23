using EgitimApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Entity.Concrete
{
    public class Trainer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialties { get; set; }
        public string Experience { get; set; }
        public string About { get; set; }
        public int Evaluation { get; set; }
        public List<Course> Courses { get; set; }
        public string Url { get; set; }
        public int BirthOfYear { get; set; }
    }
}
