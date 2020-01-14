using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class AvgangRepository :  DAL.IAvgangRepository
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
                    nyAvgangRad.StrekningId = lagreAvgang.StrekningId;


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


        public Avgang hentEnAvgang(int id)
        {
            using (var db = new DBContext())
            {


                var enDbAvgang = db.Avganger.Find(id);

                if (enDbAvgang == null)
                {
                    return null;
                }
                else
                {
                    var utAvgang = new Avgang()
                    {
                        AId = enDbAvgang.AId,
                        FraogTiltid = enDbAvgang.FraogTiltid,
                        Lengdne = enDbAvgang.Lengdne,
                        Price = enDbAvgang.Price,
                        StrekningId=enDbAvgang.StrekningId
                    };
                    return utAvgang;
                }
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
                    Price = a.Price,
                    StrekningId=a.StrekningId

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

        public bool endreAvgang(int id, Avgang endreAvgang)
        {

            using (var db = new DBContext())
            {
                try
                {
                    Avganger endreAvganger = db.Avganger.Find(id);
                    endreAvganger.FraogTiltid = endreAvgang.FraogTiltid;
                    endreAvganger.Lengdne = endreAvgang.Lengdne;
                    endreAvganger.Price = endreAvgang.Price;
                    endreAvganger.StrekningId = endreAvgang.StrekningId;



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
