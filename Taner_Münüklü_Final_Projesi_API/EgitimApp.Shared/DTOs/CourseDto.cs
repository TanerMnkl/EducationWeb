using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Shared.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int TotalCourseHour { get; set; }
        public int TotalCourseMonthly { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string About { get; set; }
        public int Price { get; set; }

        public string LevelofEducation { get; set; }
        public string AchievementsOfEducation { get; set; }
        public string LocationofEducation { get; set; }
        public string EducationContents { get; set; }
        public int EducationOfEvaluation { get; set; }
        public string EducationStatus { get; set; }
        public TrainerDto Trainer { get; set; }

        public List<TraineeDto> Trainee { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }

    }
}
