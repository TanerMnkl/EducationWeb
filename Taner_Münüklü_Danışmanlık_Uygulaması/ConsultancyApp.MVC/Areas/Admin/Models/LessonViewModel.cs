using ConsultancyApp.Entity.Concrete;

namespace ConsultancyApp.MVC.Areas.Admin.Models
{
    public class LessonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Url { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string ImageUrl { get; set; }

       
        public decimal Price { get; set; }
        public int Kontenjan { get; set; }
        public string PeriodOfStudy { get; set; }
    }
}
