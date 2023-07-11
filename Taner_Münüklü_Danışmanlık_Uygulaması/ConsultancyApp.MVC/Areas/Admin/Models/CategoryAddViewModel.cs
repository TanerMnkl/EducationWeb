using System.ComponentModel.DataAnnotations;

namespace ConsultancyApp.MVC.Areas.Admin.Models
{
    public class CategoryAddViewModel
    {
        [Required(ErrorMessage = "Ad alanı boş bırakılamalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama alanı boş bırakılmamalıdır.")]
        public string About  { get; set; }

        public bool IsActive { get; set; }
    }
}
