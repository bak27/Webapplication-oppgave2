using System;
using System.Collections.Generic;
using System.Text;
using WebAppOppgaveTo.DAL;
using WebAppOppgaveTo.MODEL;

namespace WebAppOppgaveTo.BLL
{
    public class AvgangLogikk
    {

        public bool lagreAvgang(Avgang innAvgang)
        {
            var avgangDAL = new AvgangDAL();
            return avgangDAL.lagreAvgang(innAvgang);


        }

        public List<Avgang> HentalleAvganger()
        {
            var avgangDAL = new AvgangDAL();
            List<Avgang> alleAvganger = avgangDAL.HentalleAvganger();
            return alleAvganger;


        }

        public List<Avgang> hentavganginholder(int id)
        {
            var avgangDAL = new AvgangDAL();
            List<Avgang> alleAvganger = avgangDAL.hentavganginholder(id);
            return alleAvganger;
        }

        public bool slettAvgang(int id)
        {
            var avgangDAL = new AvgangDAL();
            return avgangDAL.slettAvgang(id);
        }

        public bool endreAvgang(int id, Avganger endreAvgang)
        {
            var avgangDAL = new AvgangDAL();
            return avgangDAL.endreAvgang(id, endreAvgang);
        }


    }
}
