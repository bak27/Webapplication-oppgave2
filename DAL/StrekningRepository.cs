using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class StrekningRepository : DAL.IStrekningRepository
    {

        public bool lagreStrekning(Strekning lagreStrekning)
        {

            using (var db = new DBContext())
            {
                try
                {
                    var nyStrekningRad = new Strekninger();

                    nyStrekningRad.Fra = lagreStrekning.Fra;
                    nyStrekningRad.Til = lagreStrekning.Til;


                    db.Strekninger.Add(nyStrekningRad);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception feil)
                {
                    return false;
                }

            }
        }



        public Strekning hentEnStrekning(int id)
        {
            using (var db = new DBContext())
            {


                var enDbStrekning = db.Strekninger.Find(id);

                if (enDbStrekning == null)
                {
                    return null;
                }
                else
                {
                    var utStrekning = new Strekning()
                    {
                        SId = enDbStrekning.SId,
                        Fra = enDbStrekning.Fra,
                        Til = enDbStrekning.Til


                    };
                    return utStrekning;
                }
            }
        }



      public List<Strekning> HentalleStrekning()

        {
            using (var db1 = new DBContext())
            {
                List<Strekning> alleStrekning = db1.Strekninger.Where(k => k.SId > 0).ToList().Select(k => new Strekning
                {
                    SId = k.SId,
                    Fra = k.Fra,
                    Til = k.Til

                }).ToList();

                return alleStrekning;
            }
        }

        


        

        public bool SlettStrekning(int id)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var slettObjekt = db.Strekninger.Find(id);
                    db.Strekninger.Remove(slettObjekt);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        public bool endreStrekning(int id, Strekning endreStrekning)
        {

            using (var db = new DBContext())
            {
                try
                {
                    Strekninger endreStrekninger = db.Strekninger.Find(id);
                    endreStrekninger.Fra = endreStrekning.Fra;
                    endreStrekninger.Til = endreStrekning.Til;

                    db.SaveChanges();
                    return true;

                }
                catch (Exception feil)
                {
                    return false;
                }

            }
        }


    }
}
