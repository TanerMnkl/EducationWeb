using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Shared.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Url { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
