using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppOppgaveTo.MODEL;

namespace WebAppOppgaveTo.DAL
{
    public class TogstasjonDAL
    {
        public bool lagreTogstasjon(Togstasjon lagreTogstasjon)
        {

            using (var db = new DBContext())
            {
                try
                {
                    var nystasjonRad = new Togstasjoner();

                    nystasjonRad.Stasjon = lagreTogstasjon.Stasjon;



                    db.Togstasjoner.Add(nystasjonRad);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception feil)
                {
                    return false;
                }

            }
        }
        public List<Togstasjon> HentStasjon()

        {
            using (var db1 = new DBContext())
            {
                List<Togstasjon> alleStasjoner = db1.Togstasjoner.Where(k => k.Id > 0).ToList().Select(k => new Togstasjon
                {

                    Stasjon = k.Stasjon


                }).ToList();

                return alleStasjoner;
            }
        }


    }
}