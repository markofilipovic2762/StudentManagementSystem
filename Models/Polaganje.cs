using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMS.Models
{
    public class Polaganje
    {
        [Key]
        public int Id { get; set; }
        [Range(5,10)]
        public int? Ocena { get; set; }
        public int? OsvojenoBodova { get; set; }
        public int? RedniBrojPolaganja { get; set; }
        public bool? Polozen { get; set; }

        [Display(Name = "Student")]
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        public int IspitId { get; set; }
        public Ispit Ispit { get; set; }
    }
}
