using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Shared.DTOs
{
    public class TrainerCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialties { get; set; }
        public string Experience { get; set; }
        public string About { get; set; }
        public int Evaluation { get; set; }
        public int[] CourseIds { get; set; }

        public string Url { get; set; }
        public int BirthOfYear { get; set; }
    }
}
