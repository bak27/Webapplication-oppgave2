using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BILL
{
    public interface IStrekningLogikk
    {
        bool lagreStrekning(Strekning lagreStrekning);
        bool endreStrekning(int id, Strekning endreStrekning);
        bool SlettStrekning(int id);
        List<Strekning> HentalleStrekning();
        Strekning hentEnStrekning(int id);


    }
}
