using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sina_CSC_Project.Data
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        public string StateName { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public int CountryId { get; set; }

        public string CountryName { get; set; }
    }
}
