using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
   public class AvgangRepositoryStub : DAL.IAvgangRepository
    {
        public bool lagreAvgang(Avgang lagreAvgang)
        {

            if (lagreAvgang.FraogTiltid == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool endreAvgang(int id, Avgang endreAvgang)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }



        }
        public bool slettAvgang(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }




        }
        public List<Avgang> HentalleAvganger()
        {

            var avgangListe = new List<Avgang>();
            var avgang = new Avgang()
            {
                AId = 1,
                FraogTiltid = "10:30-17:30",
                Lengdne = "7timer",
                Price=599,
                StrekningId=1

            };
            avgangListe.Add(avgang);
            avgangListe.Add(avgang);
            avgangListe.Add(avgang);
            return avgangListe;


        }
        public Avgang hentEnAvgang(int id)
        {
            if (id == 0)
            {
                var avgang = new Avgang();
                avgang.AId = 0;
                return avgang;
            }
            else
            {
                var avgang = new Avgang()
                {
                    AId = 1,
                    FraogTiltid = "10:30-17:30",
                    Lengdne = "7timer",
                    Price=599,
                    StrekningId=1

                };
                return avgang;
            }


        }






    }
}
