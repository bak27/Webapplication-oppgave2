using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public interface IAdminRepository
    {
         bool lagreAdmin(Admin innAdmin);
         bool Admin_i_db(Admin innAdmin);



    }
}
