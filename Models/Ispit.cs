using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMS.Models
{
    public class Ispit
    {
        public int Id { get; set; }
        [Required]
        public DateTime DatumIspita { get; set; }
        [Required]
        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; }

        public string Naziv { get; set; }

    }
}
