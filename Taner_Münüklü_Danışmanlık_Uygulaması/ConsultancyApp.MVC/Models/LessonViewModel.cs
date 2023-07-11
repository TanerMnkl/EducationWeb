using ConsultancyApp.Entity.Concrete;

namespace ConsultancyApp.MVC.Models
{
    public class LessonViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price   { get; set; } 
        public string AgencyName { get; set; }
        public string AgencyUrl { get; set; }
       
        public int Kontejan { get; set; }
        public string PeriodOfStudy { get; set; }
       
    }
}
