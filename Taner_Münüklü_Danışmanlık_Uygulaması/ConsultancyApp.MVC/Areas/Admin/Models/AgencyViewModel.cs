namespace ConsultancyApp.MVC.Areas.Admin.Models
{
    public class AgencyViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Url { get; set; }
        
        public bool IsActive { get; set; }
        
        public int FoundationOfYear { get; set; }
    }
}
