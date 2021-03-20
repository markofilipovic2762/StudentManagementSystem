using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMS.Models
{
    public class Predmet
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Naziv { get; set; }
        public int ESPB { get; set; }

        [Display(Name = "Profesor")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
