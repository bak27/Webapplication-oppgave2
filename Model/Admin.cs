using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Admin
    {
      
            [DisplayName("Navn")]
            [Required(ErrorMessage = "Navn må gis")]
            public string Navn { get; set; }

            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Passord må gis")]
            public string Passord { get; set; }

            public byte[] PassordByte { get; set; }

        }


    }

