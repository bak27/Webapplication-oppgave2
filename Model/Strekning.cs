using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Strekning
    {
        [Key]
        public int SId { get; set; }

        [Display(Name = "Fra")]
        [Required(ErrorMessage = "Fra må oppgis")]
        public string Fra { get; set; }
        [Display(Name = "Til")]
        [Required(ErrorMessage = "Til må oppgis")]
        public string Til { get; set; }

    }
}
