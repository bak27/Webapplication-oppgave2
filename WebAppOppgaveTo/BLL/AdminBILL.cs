using System;
using System.Collections.Generic;
using WebAppOppgaveTo.DAL;
using WebAppOppgaveTo.MODEL;

namespace WebAppOppgaveTo.BLL
{
    public class AdminLogikk
    {

        public List<Admin> alleAdminer()
        {
            var adminDAL = new AdminDAL();
            List<Admin> alleAdminer = adminDAL.alleAdminer();
            return alleAdminer;
        }

        public List<Admin> hentAdminInnhold(string Navn)
        {
            var adminDAL = new AdminDAL();
            List<Admin> hentetAdminer = adminDAL.hentAdminInnhold(Navn);
            if (hentetAdminer.Count < 1)
            {
                return null;
            }
            return hentetAdminer;

        }
        public bool lagreAdmin(Admin innAdmin)
        {
            var adminDAL = new AdminDAL();
            return adminDAL.lagreAdmin(innAdmin);


        }

        public bool Admin_i_db(Admin innAdmin)
        {
            var adminDAL = new AdminDAL();
            return adminDAL.Admin_i_db(innAdmin);
        }



        public bool slett(string Navn)
        {
            var adminDAL = new AdminDAL();
            return adminDAL.slett(Navn);

        }

    }
}
