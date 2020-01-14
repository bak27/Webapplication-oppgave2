using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppOppgaveTo.MODEL
{
    public class Strekning
    {

        [Key]
        public int SId { get; set; }
        public string Fra { get; set; }
        public string Til { get; set; }


    }
}