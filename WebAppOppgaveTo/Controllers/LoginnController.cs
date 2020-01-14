using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BILL;
using Model;

namespace WebAppOppgaveTo.Controllers
{
    public class LoginnController : Controller
    {

        private DateTime dt = DateTime.Now;
        private IStrekningLogikk _strekningBILL;
        private IAvgangLogikk _avgangBIll;
        private IAdminLogikk _adminBILL;
        public LoginnController()
        {
            _strekningBILL = new StrekningLogikk();
            _avgangBIll = new AvgangLogikk();
            _adminBILL = new AdminLogikk();
        
        }

 public LoginnController(IAvgangLogikk stub)
        {

            _avgangBIll = stub;
           
        
        }

 public LoginnController(IStrekningLogikk stub)
        {

            _strekningBILL = stub;
           

        }

 public LoginnController(IAdminLogikk stub)
        {

            _adminBILL = stub;


        }


   public ActionResult Index()
        {

            if (Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["LoggetInn"];
            }

            return View();

        }

        public ActionResult Hjemside()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Admin innAdmin)
        {


            if (ModelState.IsValid)
            {
               
                bool loginOk = _adminBILL.Admin_i_db(innAdmin);

                if (loginOk)
                {

                    Session["LoggetInn"] = true;
                    ViewBag.Innlogget = true;
                    return RedirectToAction("AdminSide");
                }
                else
                {

                    Session["LoggetInn"] = false;
                    ViewBag.Innlogget = false;
                }

            }

            return View();
        }

        public ActionResult AdminSide()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult LoggUt()
        {
            Session["LoggetInn"] = false;
            return RedirectToAction("Index");
        }


       public ActionResult HentAlleStrekning()

        {

          List<Strekning> alleStrekning = _strekningBILL.HentalleStrekning();
            return View(alleStrekning);


        }

        public ActionResult RegistrerStrekning()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrerStrekning(Strekning innStrekning)
        {
            if (ModelState.IsValid)
            {

                bool insertOK = _strekningBILL.lagreStrekning(innStrekning);
                if (insertOK)
                {
                    try
                    {
                        string filePath = Server.MapPath(@"~\LoggFolder_For_Endring_Og_Sletting\RegistreringLogg.txt");
                        List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();
                        lines.Add("Dato: " + dt);
                        lines.Add("En ny strekning fra " + innStrekning.Fra + " til " + innStrekning.Til + " er registrert. (REGISTRERT STREKNING)");
                        lines.Add("------------------------- ");
                        lines.Add(" ");
                        System.IO.File.WriteAllLines(filePath, lines);

                    }catch(Exception feil)
                    {

                    }
                    
                    
                    return RedirectToAction("HentAlleStrekning");

                }
            }
            return View();
        }


       public ActionResult HentAlleAvgang()

        {

            
         List<Avgang> alleAvganger = _avgangBIll.HentalleAvganger();
            return View(alleAvganger);


        }

        public ActionResult EndreStrekning(int id)
        {
            Strekning enAvgang = _strekningBILL.hentEnStrekning(id);


            try
            {
                string filePath = Server.MapPath(@"~\LoggFolder_For_Endring_Og_Sletting\StrekningLogg.txt");
                List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();
                lines.Add("Dato: " + dt);
                lines.Add("Strekning id = " + enAvgang.SId + " fra '" + enAvgang.Fra + "' til '" + enAvgang.Til + "' har blitt prøvd å endres.(PRØVD Å ENDRE).");

                lines.Add("------------------------- ");
                lines.Add(" ");
                System.IO.File.WriteAllLines(filePath, lines);

            }catch(Exception feil)
            {

            }

                

            
            
            return View(enAvgang);
        }

        [HttpPost]
        public ActionResult EndreStrekning(int id, Strekning endreStrekning)
        {


            if (ModelState.IsValid)
            {

                var strekning = new StrekningLogikk();
                bool endringOK = _strekningBILL.endreStrekning(id, endreStrekning);
                
                if (endringOK)
                {
                    try
                    {
                        Strekning enAvgang = strekning.hentEnStrekning(id);
                        string filePath = Server.MapPath(@"~\LoggFolder_For_Endring_Og_Sletting\StrekningLogg.txt");
                        List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();
                        lines.Add("Dato: " + dt);
                        lines.Add("Strekning id = " + enAvgang.SId + " fra '" + enAvgang.Fra + "' til '" + enAvgang.Til + "' er endret.(ENDRET).");

                        lines.Add("------------------------- ");
                        lines.Add(" ");
                        System.IO.File.WriteAllLines(filePath, lines);
                        
                       

                    }catch(Exception feil)
                    {

                    }
                    return RedirectToAction("HentAlleStrekning");
                }
            }
            return View();
        }





        public ActionResult SlettStrekning(int id)

        {

            Strekning enstrekning = _strekningBILL.hentEnStrekning(id);
            try
            {
                string filePath = Server.MapPath(@"~\LoggFolder_For_Endring_Og_Sletting\StrekningLogg.txt");
                List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();
                lines.Add("Dato: " + dt);
                lines.Add("Strekning id = " + enstrekning.SId + " fra '" + enstrekning.Fra + "' til '" + enstrekning.Til + "' prøvd å slette.(PRØVD Å SLETTE).");

                lines.Add("------------------------- ");
                lines.Add(" ");
                System.IO.File.WriteAllLines(filePath, lines);

            }catch(Exception feil)
            {

            }
            
            return View(enstrekning);
        }

        [HttpPost]
        public ActionResult SlettStrekning(int id, Strekning slettstrekning)
        {

            Strekning enstrekning = _strekningBILL.hentEnStrekning(id);
            bool slettOK = _strekningBILL.SlettStrekning(id);
            if (slettOK)
            {
                try
                {
                    string filePath = Server.MapPath(@"~\LoggFolder_For_Endring_Og_Sletting\StrekningLogg.txt");
                    List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();
                    lines.Add("Dato: " + dt);
                    lines.Add("Strekning id = " + enstrekning.SId + " fra '" + enstrekning.Fra + "' til '" + enstrekning.Til + "' er slettet.(SLETTET).");

                    lines.Add("------------------------- ");
                    lines.Add(" ");
                    System.IO.File.WriteAllLines(filePath, lines);

                }catch(Exception feil)
                {

                }
                
                return RedirectToAction("HentAlleStrekning");
            }
            return View();
        }



       public ActionResult EndreAvgang(int id)
        {

            Avgang enAvgang = _avgangBIll.hentEnAvgang(id);

            try
            {
                string filePath = Server.MapPath(@"~\LoggFolder_For_Endring_Og_Sletting\AvgangLogg.txt");
                List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();
                lines.Add("Dato: " + dt);
                lines.Add("Avgang id = '" + enAvgang.AId + "' med tidslengden: '" + enAvgang.Lengdne + "' og prisen '" + enAvgang.Price + "' er prøvd å endres.(PRØVD Å ENDRE AVGANG)");
                lines.Add("------------------------- ");
                lines.Add(" ");
                System.IO.File.WriteAllLines(filePath, lines);

            }catch(Exception feil)
            {

            }

            

            return View(enAvgang);
        }

        [HttpPost]
        public ActionResult EndreAvgang(int id, Avgang endreAvgang)
        {


            Avgang enAvgang = _avgangBIll.hentEnAvgang(id);

            if (ModelState.IsValid)
            {

                bool endringOK = _avgangBIll.endreAvgang(id, endreAvgang);

                try
                {
                    string filePath = Server.MapPath(@"~\LoggFolder_For_Endring_Og_Sletting\AvgangLogg.txt");
                    List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();
                    lines.Add("Dato: " + dt);
                    lines.Add("Avgang id = '" + enAvgang.AId + "' med tidslengden: '" + enAvgang.Lengdne + "' og prisen '" + enAvgang.Price + "' er endret.(ENDRET AVGANG)");
                    lines.Add("------------------------- ");
                    lines.Add(" ");
                    System.IO.File.WriteAllLines(filePath, lines);

                }catch(Exception feil)
                {

                }
                

                if (endringOK)
                {
                    return RedirectToAction("HentAlleAvgang");
                }
            }
            return View();
        }



        public ActionResult slettAvgang(int id)

        {

            Avgang enAvgang = _avgangBIll.hentEnAvgang(id);
            try
            {
                string filePath = Server.MapPath(@"~\LoggFolder_For_Endring_Og_Sletting\AvgangLogg.txt");
                List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();
                lines.Add("Dato: " + dt);
                lines.Add("Avgang id = '" + enAvgang.AId + "' med tidslengden: '" + enAvgang.Lengdne + "' og prisen '" + enAvgang.Price + "' prøvd å slette å slette avgang.(PRØVD Å SLETTE AVGANG)");
                lines.Add("------------------------- ");
                lines.Add(" ");
                System.IO.File.WriteAllLines(filePath, lines);

            }catch(Exception feil)
            {

            }
            
            return View(enAvgang);
        }

        [HttpPost]
        public ActionResult slettAvgang(int id, Avgang slettAvgang)
        {

            Avgang enAvgang = _avgangBIll.hentEnAvgang(id);
            bool slettOK = _avgangBIll.slettAvgang(id);
            if (slettOK)
            {
                try
                {
                    string filePath = Server.MapPath(@"~\LoggFolder_For_Endring_Og_Sletting\AvgangLogg.txt");
                    List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();
                    lines.Add("Dato: " + dt);
                    lines.Add("Avgang id = '" + enAvgang.AId + "' med tidslengden: '" + enAvgang.Lengdne + "' og prisen '" + enAvgang.Price + "' er slettet.(SLETTET AVGANG)");
                    lines.Add("------------------------- ");
                    lines.Add(" ");

                    System.IO.File.WriteAllLines(filePath, lines);

                }catch(Exception feil)
                {

                }
                

                return RedirectToAction("HentAlleAvgang");
            }
            return View();
        }

        public ActionResult RegistrerAvgang()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrerAvgang(Avgang innAvgang)
        {
            if (ModelState.IsValid)
            {

                bool insertOK = _avgangBIll.lagreAvgang(innAvgang);
                if (insertOK)
                {
                    try
                    {
                        string filePath = Server.MapPath(@"~\LoggFolder_For_Endring_Og_Sletting\RegistreringLogg.txt");
                        List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();
                        lines.Add("Dato: " + dt);
                        lines.Add("Avgang id = '" + innAvgang.AId + "' med tidslengden: '" + innAvgang.Lengdne + "' og prisen '" + innAvgang.Price + "' er registrert.(AVGANG REGISTRERT)");
                        lines.Add("------------------------- ");
                        lines.Add(" ");
                        System.IO.File.WriteAllLines(filePath, lines);

                    }catch(Exception feil)
                    {

                    }
                    

                    return RedirectToAction("HentAlleAvgang");
                }
            }
            return View();
        }







    }



}