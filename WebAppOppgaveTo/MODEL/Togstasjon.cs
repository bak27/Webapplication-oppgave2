using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppOppgaveTo.MODEL
{
    public class Togstasjon
    {
        [Key]
        public int Id { get; set; }
        public string Stasjon { get; set; }

    }
}