using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppOppgaveTo.MODEL;

namespace WebAppOppgaveTo.DAL
{
    public class StrekningDAL
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
        public List<Strekninger> FraStrekninger()

        {
            using (var db1 = new DBContext())
            {
                List<Strekninger> alleStrekning = db1.Strekninger.OrderBy(k => k.Fra).Distinct().ToList().Select(k => new Strekninger
                {

                    SId = k.SId,
                    Fra = k.Fra

                }).ToList();

                return alleStrekning;
            }
        }




        public int FinnStrekningId(string fra, string til)

        {

            using (var db1 = new DBContext())
            {

                int str = db1.Strekninger.Where(r => r.SId > 0 && r.Fra == fra && r.Til == til).Select(r => r.SId).FirstOrDefault();

                return str;
            }

        }


        public List<Strekninger> TilStrekninger(string fra, string til)

        {
            using (var db1 = new DBContext())
            {
                List<Strekninger> alleStrekning = db1.Strekninger.Where(k => k.Fra == fra && k.Til == til).ToList().Select(k => new Strekninger
                {

                    SId = k.SId,
                    Fra = k.Fra,
                    Til = k.Til

                }).ToList();

                return alleStrekning;
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

        public List<Strekning> hentStrekninginholder(int id)
        {

            using (var db1 = new DBContext())
            {
                List<Strekning> alleStrekning = db1.Strekninger.Where(k => k.SId == id).ToList().Select(k => new Strekning
                {
                    SId = k.SId,
                    Fra = k.Fra,
                    Til = k.Til

                }).ToList();

                return alleStrekning;
            }


        }

        public bool slettStrekning(int id)
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
                    db.Strekninger.Add(endreStrekninger);
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
