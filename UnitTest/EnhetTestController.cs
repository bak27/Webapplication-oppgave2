using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BILL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Model;
using MvcContrib.TestHelper;
using WebAppOppgaveTo.Controllers;

namespace UnitTest
{
   [TestClass]
    public class EnhetTestController
    {


      [TestMethod]
      public void Index1()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new LoginnController();
            SessionMock.InitializeController(controller);
            controller.Session["LoggetInn"] = null; 
            var result = (ViewResult)controller.Index();
            Assert.AreEqual("", result.ViewName);
        }


        [TestMethod]
        public void Index2()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new LoginnController();
            SessionMock.InitializeController(controller);
            controller.Session["LoggetInn"] = true;
            var result = (ViewResult)controller.Index();
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void Index3()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new LoginnController();
            SessionMock.InitializeController(controller);
            controller.Session["LoggetInn"] = false;
            var result = (ViewResult)controller.Index();
            Assert.AreEqual("", result.ViewName);
        }





        [TestMethod]
        public void AdminSide_IkkeLoggin()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new LoginnController();
            SessionMock.InitializeController(controller);
            controller.Session["LoggetInn"] = null;
            var result = (RedirectToRouteResult)controller.AdminSide();
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");

        }

        [TestMethod]
        public void AdminSide_Loggin()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new LoginnController();
            SessionMock.InitializeController(controller);
            controller.Session["LoggetInn"] = true;
            controller.ViewData.ModelState.AddModelError("adminside", "admin side er åpen");
            var actionResult = (ViewResult)controller.AdminSide();
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");

        }




        [TestMethod]
        public void Hjemside1()
        {
            var controller = new LoginnController();
            var result = (ViewResult)controller.Hjemside();
            Assert.AreEqual("", result.ViewName);
        }


          [TestMethod]
        public void LoggUt1()
        {

            var SessionMock = new TestControllerBuilder();
            var controller = new LoginnController();
            SessionMock.InitializeController(controller);
            controller.Session["LoggetInn"] = null;
            var result = (RedirectToRouteResult)controller.LoggUt();
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }


        [TestMethod]
        public void Index_Admin_Ok()
        {
            var innadmin = new Admin
            {
                Navn = "Admin",
                Passord = "Admin"
            };
            var SessionMock = new TestControllerBuilder();
            var controller = new LoginnController(new AdminLogikk(new AdminRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["LoggetInn"] = true;
            var result = (RedirectToRouteResult)controller.Index(innadmin);
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "AdminSide");
        }

        [TestMethod]
        public void Index_Admin_feil()
        {
            var innadmin = new Admin
            {
                Navn = "Admin",
                Passord = " "
            };
            var SessionMock = new TestControllerBuilder();
            var controller = new LoginnController(new AdminLogikk(new AdminRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["LoggetInn"] = null;
            controller.ViewData.ModelState.AddModelError("passord", "Ikke oppgitt eller feil");
            var actionResult = (ViewResult)controller.Index(innadmin);
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");
        }



        [TestMethod]   
     public void HentalleAvganger()
        {
            var controller = new LoginnController(new AvgangLogikk(new AvgangRepositoryStub()));
            
            var forventetResultet = new List<Avgang>();
            var avgang = new Avgang()
            {
                AId = 1,
                FraogTiltid = "10:30-17:30",
                Lengdne = "7timer",
                Price = 599,
                StrekningId=1
            };

            forventetResultet.Add(avgang);
            forventetResultet.Add(avgang);
            forventetResultet.Add(avgang);
            
            var actionResult = (ViewResult)controller.HentAlleAvgang();
            var resultat = (List<Avgang>)actionResult.Model;
            

            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultet[i].AId, resultat[i].AId);
                Assert.AreEqual(forventetResultet[i].FraogTiltid, resultat[i].FraogTiltid);
                Assert.AreEqual(forventetResultet[i].Lengdne, resultat[i].Lengdne);
                Assert.AreEqual(forventetResultet[i].Price, resultat[i].Price);
                
            }


        }


        [TestMethod]
        public void HentalleStrekning()
        {
            var controller = new LoginnController(new StrekningLogikk(new StrekningRepositoryStub()));

            var forventetResultet = new List<Strekning>();
            var strekning = new Strekning()
            {
                SId = 1,
                Fra= "Oslo",
                Til = "Bergen"
               
            };

            forventetResultet.Add(strekning);
            forventetResultet.Add(strekning);
            forventetResultet.Add(strekning);
            
            var actionResult = (ViewResult)controller.HentAlleStrekning();
            var resultat = (List<Strekning>)actionResult.Model;
            

            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultet[i].SId, resultat[i].SId);
                Assert.AreEqual(forventetResultet[i].Fra, resultat[i].Fra);
                Assert.AreEqual(forventetResultet[i].Til, resultat[i].Til);
                

            }


        }

        [TestMethod]
        public void RegistrerStrekning()
        {
            
            var controller = new LoginnController(new StrekningLogikk(new StrekningRepositoryStub()));

            
            var actionResult = (ViewResult)controller.RegistrerStrekning();

            
            Assert.AreEqual(actionResult.ViewName, "");
        }
        
        
        [TestMethod]
        public void RegistrerStrekning_Post_OK()
        {
            
            var controller = new LoginnController(new StrekningLogikk(new StrekningRepositoryStub()));
            
            var innstrekning = new Strekning()
            {
                Fra = "Oslo",
                Til = "Bergen"
               
            };
            
            
            var result = (RedirectToRouteResult)controller.RegistrerStrekning(innstrekning);

            
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "HentAlleStrekning");
        }
        
        
        [TestMethod]
        public void RegistrerStrekning_Post_Model_feil()
        {
            
            var controller = new LoginnController(new StrekningLogikk(new StrekningRepositoryStub()));
            var innstrekning = new Strekning();
            controller.ViewData.ModelState.AddModelError("fra", "Ikke oppgitt fra-destinasjon");

            
            var actionResult = (ViewResult)controller.RegistrerStrekning(innstrekning);

            
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void RegistrerStrekning_Post_DB_feil()
        {
            
            var controller = new LoginnController(new StrekningLogikk(new StrekningRepositoryStub()));
            var innstrekning = new Strekning();
            innstrekning.Fra = "";

            
            var actionResult = (ViewResult)controller.RegistrerStrekning(innstrekning);

            
            Assert.AreEqual(actionResult.ViewName, "");
        }
        
        [TestMethod]
        public void SlettStrekning()
        {
            
            var controller = new LoginnController(new StrekningLogikk(new StrekningRepositoryStub()));

            
            var actionResult = (ViewResult)controller.SlettStrekning(1);
            var resultat = (Strekning)actionResult.Model;

            
            Assert.AreEqual(actionResult.ViewName, "");


        }
        [TestMethod]
        public void SlettetStrekning_funnet_Post()
        {
            
            var controller = new LoginnController(new StrekningLogikk(new StrekningRepositoryStub()));
            var innstrekning = new Strekning()
            {
                Fra = "Oslo",
                Til = "Bergen"
               
            };

            
            var actionResult = (RedirectToRouteResult)controller.SlettStrekning(1, innstrekning);

           
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "HentAlleStrekning");
        }
        [TestMethod]
        public void SlettStrekning_ikke_funnet_Post()
        {
            
            var controller = new LoginnController(new StrekningLogikk(new StrekningRepositoryStub()));
            var innstrekning = new Strekning()
            {
                Fra = "Oslo",
                Til = "Bergen"

            };

            
            var actionResult = (ViewResult)controller.SlettStrekning(0, innstrekning);

            
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void EndreStrekning()
        {
            
            var controller = new LoginnController(new StrekningLogikk(new StrekningRepositoryStub()));

            
            var actionResult = (ViewResult)controller.EndreStrekning(1);

            
            Assert.AreEqual(actionResult.ViewName, "");
        }
        
        
        [TestMethod]
        public void EndreStrekning_Ikke_Funnet_Ved_View()
        {
            
            var controller = new LoginnController(new StrekningLogikk(new StrekningRepositoryStub()));

            
            var actionResult = (ViewResult)controller.EndreStrekning(0);
            var strekningResultat = (Strekning)actionResult.Model;

            
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(strekningResultat.SId, 0);
        }
        
        
        [TestMethod]
        public void EndreStrekning_ikke_funnet_Post()
        {
            
            var controller = new LoginnController(new StrekningLogikk(new StrekningRepositoryStub()));
            var innstrekning = new Strekning()
            {
                SId=0,
                Fra = "Oslo",
                Til = "Bergen"

            };

            
            var actionResult = (ViewResult)controller.EndreStrekning(0, innstrekning);

            
            Assert.AreEqual(actionResult.ViewName, "");
        }
        
        
        [TestMethod]
        public void EndreStrekning_feil_validering_Post()
        {
            
            var controller = new LoginnController(new StrekningLogikk(new StrekningRepositoryStub()));
            var innstrekning = new Strekning();
            controller.ViewData.ModelState.AddModelError("feil", "ID = 0");

            
            var actionResult = (ViewResult)controller.EndreStrekning(0, innstrekning);

            
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewData.ModelState["feil"].Errors[0].ErrorMessage, "ID = 0");
            Assert.AreEqual(actionResult.ViewName, "");
        }
        
        
        [TestMethod]
        public void EndreStrekning_funnet()
        {
            
            var controller = new LoginnController(new StrekningLogikk(new StrekningRepositoryStub()));
            var innstrekning = new Strekning()
            {
              Fra="Oslo",
              Til="Bergen"
            };
            
            var actionResultat = (RedirectToRouteResult)controller.EndreStrekning(1, innstrekning);

            
            Assert.AreEqual(actionResultat.RouteName, "");
            Assert.AreEqual(actionResultat.RouteValues.Values.First(), "HentAlleStrekning");
        }


    

        [TestMethod]
        public void RegistrerAvgang()
        {
            
            var controller = new LoginnController(new AvgangLogikk(new AvgangRepositoryStub()));

            
            var actionResult = (ViewResult)controller.RegistrerAvgang();

            
            Assert.AreEqual(actionResult.ViewName, "");
        }
        
        
        [TestMethod]
        public void RegistrerAvgang_Post_OK()
        {
            
            var controller = new LoginnController(new AvgangLogikk(new AvgangRepositoryStub()));

            var innavgang = new Avgang()
            {
                FraogTiltid = "10:30-17:30",
                Lengdne = "7timer",
                Price=599,
                StrekningId=1

            };
            
            var result = (RedirectToRouteResult)controller.RegistrerAvgang(innavgang);

            
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "HentAlleAvgang");
        }
        
        
        [TestMethod]
        public void RegistrerAvgang_Post_Model_feil()
        {
            
            var controller = new LoginnController(new AvgangLogikk(new AvgangRepositoryStub()));
            var innavgang = new Avgang();
            controller.ViewData.ModelState.AddModelError("fraogtil tid", "Ikke oppgitt fra og til tid");

            
            var actionResult = (ViewResult)controller.RegistrerAvgang(innavgang);

            
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");
        }
        
        
        [TestMethod]
        public void RegistrerAvgang_Post_DB_feil()
        {
            
            var controller = new LoginnController(new AvgangLogikk(new AvgangRepositoryStub()));
            var innavgang = new Avgang();
            innavgang.FraogTiltid = "";

            
            var actionResult = (ViewResult)controller.RegistrerAvgang(innavgang);

            
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void SlettAvgang()
        {
            
            var controller = new LoginnController(new AvgangLogikk(new AvgangRepositoryStub()));

            
            var actionResult = (ViewResult)controller.slettAvgang(1);
            var resultat = (Avgang)actionResult.Model;

            
            Assert.AreEqual(actionResult.ViewName, "");


        }
        
        
        [TestMethod]
        public void SlettetAvgang_funnet_Post()
        {
            
            var controller = new LoginnController(new AvgangLogikk(new AvgangRepositoryStub()));
            var innavgang = new Avgang()
            {
                FraogTiltid = "10:30-17:30",
                Lengdne = "7timer",
                Price=599

            };

            
            var actionResult = (RedirectToRouteResult)controller.slettAvgang(1, innavgang);

            
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "HentAlleAvgang");
        }
        
        
        [TestMethod]
        public void SlettAvgang_ikke_funnet_Post()
        {
            
            var controller = new LoginnController(new AvgangLogikk(new AvgangRepositoryStub()));
            var innavgang = new Avgang()
            {
                FraogTiltid = "10:30-17:30",
                Lengdne = "7timer",
                Price = 599,
                StrekningId=1

            };

            
            var actionResult = (ViewResult)controller.slettAvgang(0, innavgang);

            
            Assert.AreEqual(actionResult.ViewName, "");
        }
        
        
        [TestMethod]
        public void EndreAvgang()
        {
            
            var controller = new LoginnController(new AvgangLogikk(new AvgangRepositoryStub()));

            
            var actionResult = (ViewResult)controller.EndreAvgang(1);

            
            Assert.AreEqual(actionResult.ViewName, "");
        }
        
        
        
        [TestMethod]
        public void EndreAvgang_Ikke_Funnet_Ved_View()
        {
            
            var controller = new LoginnController(new AvgangLogikk(new AvgangRepositoryStub()));

            
            var actionResult = (ViewResult)controller.EndreAvgang(0);
            var avgangResultat = (Avgang)actionResult.Model;

            
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(avgangResultat.AId, 0);
        }
        
        
        
        [TestMethod]
        public void EndreAvgang_ikke_funnet_Post()
        {
            
            var controller = new LoginnController(new AvgangLogikk(new AvgangRepositoryStub()));
            var innavgang = new Avgang()
            {
                AId=0,
                FraogTiltid = "10:30-17:30",
                Lengdne = "7timer",
                Price = 599,
                StrekningId=1

            };

            
            var actionResult = (ViewResult)controller.EndreAvgang(0, innavgang);

            
            Assert.AreEqual(actionResult.ViewName, "");
        }
        
        
        [TestMethod]
        public void EndreAvgang_feil_validering_Post()
        {

            var controller = new LoginnController(new AvgangLogikk(new AvgangRepositoryStub()));
            var innavgang = new Avgang();
            controller.ViewData.ModelState.AddModelError("feil", "ID = 0");


            var actionResult = (ViewResult)controller.EndreAvgang(0, innavgang);


            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewData.ModelState["feil"].Errors[0].ErrorMessage, "ID = 0");
            Assert.AreEqual(actionResult.ViewName, "");
        }
        
        
        [TestMethod]
        public void EndreAvgang_funnet()
        {

            var controller = new LoginnController(new AvgangLogikk(new AvgangRepositoryStub()));
            var innavgang = new Avgang()
            {
                FraogTiltid = "10:30-17:30",
                Lengdne = "7timer",
                Price = 599,
                StrekningId=1

            };

            var actionResultat = (RedirectToRouteResult)controller.EndreAvgang(1, innavgang);


            Assert.AreEqual(actionResultat.RouteName, "");
            Assert.AreEqual(actionResultat.RouteValues.Values.First(), "HentAlleAvgang");
        }




    }
}
