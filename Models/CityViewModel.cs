﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sina_CSC_Project.Data;

namespace Sina_CSC_Project.Models
{
    public class CityCreateViewModel
    {
        [Required]
        [Display(Name = "نام شهر")]
        public string CityName { get; set; }

        public StateDetailViewModel State { get; set; }
        [Display(Name = "کد استان")]
        public int StateId { get; set; }

        public IEnumerable<SelectListItem> StateSelectListItems { get; set; }

        public CountryDetailViewModel Country { get; set; }
        [Display(Name = "کد کشور")]
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public IEnumerable<SelectListItem> CountrySelectListItems { get; set; }
    }

    public class CityDetailViewModel
    {
        [Display(Name = "کد شهر")]
        public int CityId { get; set; }
        [Display(Name = "نام شهر")]
        public string CityName { get; set; }

        public StateDetailViewModel State { get; set; }
        [Display(Name = "نام استان")]
        public string StateName { get; set; }


        public CountryDetailViewModel Country { get; set; }
        [Display(Name = "نام کشور")]
        public string CountryName { get; set; }
    }
}
