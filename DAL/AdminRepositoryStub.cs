using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
   public class AdminRepositoryStub : DAL.IAdminRepository
    {
        public bool lagreAdmin(Admin innAdmin)
        {
            if (innAdmin.Navn == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
       public bool Admin_i_db(Admin innAdmin)
        {

            if (innAdmin.Navn == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }


    }
}
