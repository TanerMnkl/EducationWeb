using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Entity.Concrete
{
    public class CoursesTrainees
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
    }
}
