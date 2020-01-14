using System;
using System.Collections.Generic;
using System.Text;
using WebAppOppgaveTo.DAL;
using WebAppOppgaveTo.MODEL;

namespace WebAppOppgaveTo.BLL
{
    public class StrekningLogikk
    {
        public bool lagreStrekning(Strekning innstrekning)
        {
            var strekningDAL = new StrekningDAL();
            return strekningDAL.lagreStrekning(innstrekning);


        }

        public List<Strekning> HentalleStrekning()
        {
            var strekningDAL = new StrekningDAL();
            List<Strekning> alleStrekninger = strekningDAL.HentalleStrekning();
            return alleStrekninger;


        }

        public List<Strekning> hentStrekninginholder(int id)
        {
            var strekningDAL = new StrekningDAL();
            List<Strekning> alleStrekning = strekningDAL.hentStrekninginholder(id);
            return alleStrekning;
        }

        public bool slettStrekning(int id)
        {
            var strekningDAL = new StrekningDAL();
            return strekningDAL.slettStrekning(id);
        }

        public bool endreStrekning(int id, Strekning endreStrekning)
        {
            var strekningDAL = new StrekningDAL();
            return strekningDAL.endreStrekning(id, endreStrekning);
        }




    }
}
