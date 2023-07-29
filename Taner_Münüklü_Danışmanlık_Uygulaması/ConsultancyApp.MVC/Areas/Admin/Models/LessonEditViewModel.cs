using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConsultancyApp.MVC.Areas.Admin.Models
{
    public class LessonEditViewModel
    {
        public int Id { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]
        public string Name { get; set; }
        [DisplayName("Hakkında")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]

        public string About { get; set; }
        public string Url { get; set; }
        public IFormFile ImageFile { get; set; }

        public string ImageUrl { get; set; } = "default-profile.jpg";

        [DisplayName("Fiyat")]


        public decimal Price { get; set; } = 0;
        [DisplayName("Kontenjan")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]

        public int Kontenjan { get; set; }
        [DisplayName("Ders Saati")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
      
        public int PeriodOfStudy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int AgencyId { get; set; }
        public  DateTime ModifiedDate { get; set; } = DateTime.Now;
        public List<SelectListItem> YearList { get; set; }
        public List<SelectListItem> AgencyList { get; set; }
        public List<CategoryViewModel> CategoryList { get; set; }
        public List<int> SelectedCategoryIds { get; set; }
    }
}
