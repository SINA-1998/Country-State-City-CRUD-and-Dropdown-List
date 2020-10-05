using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sina_CSC_Project.Data
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }
        public int StateId { get; set; }

        public string StateName { get; set; }
        public string CountryName { get; set; }
    }
}
