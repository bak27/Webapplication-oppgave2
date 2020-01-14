using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BILL
{
    public interface IAvgangLogikk
    {
        bool lagreAvgang(Avgang lagreAvgang);
        bool endreAvgang(int id, Avgang endreAvgang);
        bool slettAvgang(int slettId);
        List<Avgang> HentalleAvganger();
        Avgang hentEnAvgang(int id);


    }
}
