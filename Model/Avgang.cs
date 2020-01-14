using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Avgang
    {

        [Key]
        public int AId { get; set; }
        
        [Display(Name = "FraogTiltid")]
        [Required(ErrorMessage = "FraogTiltid må oppgis")]
        public string FraogTiltid { get; set; }
        
        [Display(Name = "Lengdne")]
        [Required(ErrorMessage = "Lengdne må oppgis")]
        public string Lengdne { get; set; }
        
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price må oppgis")]
        public double Price { get; set; }
        
        [Display(Name = "StrekningId")]
        [Required(ErrorMessage = "StrekningId må oppgis")]
        public int StrekningId { get; set; }

    }
}
