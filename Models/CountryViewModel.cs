using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sina_CSC_Project.Models
{
    public class CountryCreateViewModel
    {
        [Required]
        [Display(Name = "نام کشور")]
        public string CountryName { get; set; }
    }

    public class CountryDetailViewModel
    {
        [Display(Name = "کد کشور")]
        public int CountryId { get; set; }
        [Display(Name = "نام کشور")]
        public string CountryName { get; set; }
    }
}
