using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAppOppgaveTo.MODEL;

namespace WebAppOppgaveTo.MODEL
{
    public class Avgang
    {
        [Key]
        public int AId { get; set; }
        public string FraogTiltid { get; set; }
        public string Lengdne { get; set; }
        public double Price { get; set; }
        public int StrekningId { get; set; }
    }
}