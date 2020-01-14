using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppOppgaveTo.MODEL;

namespace WebAppOppgaveTo.DAL
{
    public class AvgangDAL
    {
        public bool lagreAvgang(Avgang lagreAvgang)
        {

            using (var db = new DBContext())
            {
                try
                {
                    var nyAvgangRad = new Avganger();
                    nyAvgangRad.FraogTiltid = lagreAvgang.FraogTiltid;
                    nyAvgangRad.Lengdne = lagreAvgang.Lengdne;
                    nyAvgangRad.Price = lagreAvgang.Price;
                    nyAvgangRad.Strekning.SId = lagreAvgang.StrekningId;


                    db.Avganger.Add(nyAvgangRad);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception feil)
                {
                    return false;
                }

            }
        }



        public List<Avgang> HentalleAvganger(int id)

        {

            using (var db1 = new DBContext())
            {
                var avgang = new Avgang();
                List<Avgang> alleAvganger = db1.Avganger.Where(a => a.Strekning.SId == id).ToList().Select(a => new Avgang
                {

                    AId = a.AId,
                    FraogTiltid = a.FraogTiltid,
                    Lengdne = a.Lengdne,
                    Price = a.Price

                }).ToList();
                // Debug.WriteLine(alleAvganger);
                return alleAvganger;
            }
        }


        public List<Avgang> hentavganginholder(int id)
        {
            using (var db1 = new DBContext())
            {
                var avgang = new Avgang();
                List<Avgang> alleAvganger = db1.Avganger.Where(a => a.AId == id).ToList().Select(a => new Avgang
                {

                    AId = a.AId,
                    FraogTiltid = a.FraogTiltid,
                    Lengdne = a.Lengdne,
                    Price = a.Price

                }).ToList();
                // Debug.WriteLine(alleAvganger);
                return alleAvganger;
            }




        }






        public List<Avgang> HentalleAvganger()

        {

            using (var db1 = new DBContext())
            {
                var avgang = new Avgang();
                List<Avgang> alleAvganger = db1.Avganger.Where(a => a.AId > 0).ToList().Select(a => new Avgang
                {

                    AId = a.AId,
                    FraogTiltid = a.FraogTiltid,
                    Lengdne = a.Lengdne,
                    Price = a.Price

                }).ToList();
                // Debug.WriteLine(alleAvganger);
                return alleAvganger;
            }
        }

        public bool slettAvgang(int id)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var slettObjekt = db.Avganger.Find(id);
                    db.Avganger.Remove(slettObjekt);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        public bool endreAvgang(int id, Avganger endreAvgang)
        {

            using (var db = new DBContext())
            {
                try
                {
                    Avganger endreAvganger = db.Avganger.Find(id);
                    endreAvganger.FraogTiltid = endreAvgang.FraogTiltid;
                    endreAvganger.Lengdne = endreAvgang.Lengdne;
                    endreAvganger.Price = endreAvgang.Price;
                    endreAvganger.Strekning = endreAvgang.Strekning;


                    db.Avganger.Add(endreAvganger);
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
