using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebAppOppgaveTo.MODEL;

namespace WebAppOppgaveTo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Hjemside()
        {
            return View();
        }


        public ActionResult Bestill()
        {
            return View();
        }



    }
}