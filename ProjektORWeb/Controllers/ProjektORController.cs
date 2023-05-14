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

            return View();
        }

        public IActionResult PokazProjekty()
        {
            //1. Pobranie danych (zazwyczaj z BD)
            var dbContext = new ProjektORDbContext();
            Console.WriteLine(dbContext);
            Console.WriteLine(dbContext.ProjektOrs);

            var projekty = dbContext.ProjektOrs.ToList();


            //2. Przekazanie danych do widoku
            //2.1 ViewBag - dynamiczny typ danych rzadziej
            //ViewBag.Projekt = "Lista studentów";

            //2.2 Dane silnie typowane (bezposrednio w View()
            return View(projekty);


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
            public IActionResult Create(ProjektOR nowyProjekt)
            {
                //Walidacja
                if (ModelState.IsValid) // ==True
                {
                //zapis do bazy danych
                //powrot do listy projektow
                    return RedirectToAction("PokazProjekty");
                }
                //dodanie projektu do bazy
                return View (nowyProjekt);
                
            }
        }
    }

