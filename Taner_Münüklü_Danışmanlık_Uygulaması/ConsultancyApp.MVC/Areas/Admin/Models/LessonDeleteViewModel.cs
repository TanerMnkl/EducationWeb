namespace ConsultancyApp.MVC.Areas.Admin.Models
{
    public class LessonDeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
       
       
        public bool IsActive { get; set; }

        public string AgencyName { get; set; }



        public decimal Price { get; set; }
        public int Kontenjan { get; set; }
        public int PeriodOfStudy { get; set; }



    }
}
