using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BILL
{
    public class StrekningLogikk : BILL.IStrekningLogikk
    {
        private IStrekningRepository _repository;

        public StrekningLogikk()
        {
            _repository = new StrekningRepository(); 
        }

        public StrekningLogikk(IStrekningRepository stub)
        {
            _repository = stub;
        }
        
      public bool lagreStrekning(Strekning innstrekning)
        {
            
            return _repository.lagreStrekning(innstrekning);


        }

        public List<Strekning> HentalleStrekning()
        {
           
            List<Strekning> alleStrekninger = _repository.HentalleStrekning();
            return alleStrekninger;


        }

        public Strekning hentEnStrekning(int id)
        {
           
            return _repository.hentEnStrekning(id);
        }



       

        public bool SlettStrekning(int id)
        {
            
            return _repository.SlettStrekning(id);
        }

        public bool endreStrekning(int id, Strekning endreStrekning)
        {
            
            return _repository.endreStrekning(id, endreStrekning);
        }




    }
}

