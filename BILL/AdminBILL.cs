using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BILL
{
    public class AdminLogikk : BILL.IAdminLogikk
     {

        private IAdminRepository _repository;

        public AdminLogikk()
        {
            _repository = new AdminRepository();
        }

        public AdminLogikk(IAdminRepository stub)
        {
            _repository = stub;

        }


        

        
        public bool lagreAdmin(Admin innAdmin)
        {
           
            return _repository.lagreAdmin(innAdmin);


        }

        public bool Admin_i_db(Admin innAdmin)
        {
            
            return _repository.Admin_i_db(innAdmin);
        }



        

    }
}
