﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ConsultancyApp.MVC.Areas.Admin.Models
{
    public class AgencyAddViewModel
    {

        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter uzunluğunda olmalıdır.")]
        public string Name { get; set; }
        [DisplayName("Hakkında")]
        [Required(ErrorMessage ="{0} alanı boş bırakılmamalıdır.")]
        public string About { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; } = "default-profile.jpg";
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        [DisplayName("Kuruluş Yılı")]
        public int FoundationOfYear { get; set; }
        public List<SelectListItem> Years { get; set; }


    }
}
