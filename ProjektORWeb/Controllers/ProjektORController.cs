using Microsoft.AspNetCore.Mvc;
using ProjektORWeb.Models;
//2 commit
namespace ProjektORWeb.Controllers
{
    public class ProjektORController : Controller
    {

        public IActionResult Index()
        {
            
            return View();
        }




        public IActionResult Opcje()
        {
            //1. Pobranie danych (zazwyczaj z BD)
            var projekt = new List<ProjektOR>();

            var s1 = new ProjektOR
            {
                
                

            };

            var s2 = new ProjektOR
            {
                
                NumerProjektu = 111,
                Rok = 2020

            };

            projekt.Add(s1);
            projekt.Add(s2);

            //2. Przekazanie danych do widoku
            //2.1 ViewBag - dynamiczny typ danych rzadziej
            //ViewBag.Projekt = "Lista studentów";

            //2.2 Dane silnie typowane (bezposrednio w View()
            return View(projekt);
        }

        public IActionResult Details(int id)
        {
            ProjektOR projekt = null;
            if (id == 5)
            {
                projekt = new ProjektOR
                {
                    
                    NumerProjektu = 4566,
                    Rok = 2021

                };
            }            
            else if (id == 6)
            {
               projekt = new ProjektOR
                {
                    

                }; 

            };
            return View(projekt);

        }

        public IActionResult Create() 
        { 

            return View();
        }

        [HttpPost]
        public IActionResult Create (ProjektOR nowyProjekt)
        {
            //Walidacja po stronie serwera
            //dodanie projektu do bazy
            return RedirectToAction("Index");
        }
    }
}
