using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
   public class StrekningRepositoryStub : DAL.IStrekningRepository
    {
       public bool lagreStrekning(Strekning lagreStrekning)
        {

            if (lagreStrekning.Fra == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }
       public bool endreStrekning(int id, Strekning endreStrekning)
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
      public  bool SlettStrekning(int id)
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
      public  List<Strekning> HentalleStrekning()
        {

            var strekningListe = new List<Strekning>();
            var strekning = new Strekning()
            {
            SId=1,
            Fra="Oslo",
            Til="Bergen"
            
                };
            strekningListe.Add(strekning);
            strekningListe.Add(strekning);
            strekningListe.Add(strekning);
            return strekningListe;


        }
       public Strekning hentEnStrekning(int id)
        {
            if (id == 0)
            {
                var strekning = new Strekning();
                strekning.SId = 0;
                return strekning;
            }
            else
            {
                var strekning = new Strekning()
                {
                    SId = 1,
                    Fra = "Oslo",
                    Til = "Bergen"
                    
                };
                return strekning;
            }


        }



    }
}
