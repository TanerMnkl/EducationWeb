using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ConsultancyApp.MVC.Areas.Admin.Models
{
    public class LessonAddViewModel
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]
        public string Name { get; set; }
        [DisplayName("Hakkında")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]

        public string About { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }= "default-profile.jpg";

        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]
        public decimal Price { get; set; }
        [DisplayName("Kontenjan")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]
        public int Kontenjan { get; set; }
        [DisplayName("Ders Saati")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]
        public string PeriodOfStudy { get; set; }
        public bool IsActive { get; set; }
    }
}
