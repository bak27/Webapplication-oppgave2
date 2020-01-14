using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BILL
{
    public class AvgangLogikk : BILL.IAvgangLogikk
    {


        private IAvgangRepository _repository;

        public AvgangLogikk()
        {
            _repository = new AvgangRepository();
        }

        public AvgangLogikk(IAvgangRepository stub)
        {
            _repository = stub;
        }




        public bool lagreAvgang(Avgang innAvgang)
        {
            
            return _repository.lagreAvgang(innAvgang);


        }

        public List<Avgang> HentalleAvganger()
        {
            
            List<Avgang> alleAvganger = _repository.HentalleAvganger();
            return alleAvganger;


        }

       


        public Avgang hentEnAvgang(int id)
        {
           
            return _repository.hentEnAvgang(id);
        }



        public bool slettAvgang(int id)
        {
           
            return _repository.slettAvgang(id);
        }

        public bool endreAvgang(int id, Avgang endreAvgang)
        {
           
            return _repository.endreAvgang(id, endreAvgang);
        }


    }
}
