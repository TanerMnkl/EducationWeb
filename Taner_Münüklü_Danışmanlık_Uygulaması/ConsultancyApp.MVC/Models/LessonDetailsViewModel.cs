namespace ConsultancyApp.MVC.Models
{
    public class LessonDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
       
        public string AgencyAbout { get; set; }
       
        public string AgencyName { get; set; }
        public string AgencyUrl { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public int PeriodOfStudy { get; set; }
        public int Kontenjan { get; set; }
        
       
        public string About { get; set; }
    }
}
