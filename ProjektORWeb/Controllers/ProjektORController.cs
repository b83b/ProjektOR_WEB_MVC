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

        public IActionResult PokazProjekty(string query) //parametr query pochodzi z metody GET - szukaj
        {
            //1. Pobranie danych (zazwyczaj z BD)
            var dbContext = new Models.BzrdDbContext();
            //WHERE
            var projekty = dbContext.ProjektOrs
                                        .Where(p1 => string.IsNullOrWhiteSpace(query) || (p1.Email).Contains(query)|| (p1.Uwagi).Contains(query))
                                        .ToList();


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
                var dbContext = new Models.BzrdDbContext(); //polaczenie z bazą
                dbContext.ProjektOrs.Add(nowyProjekt); // dodanie do kolekcji projektów moje pola 
                dbContext.SaveChanges(); // wstawienie rekordu do bazy danych
                                         //powrot do listy projektow
                return RedirectToAction("PokazProjekty");
            }
            //dodanie projektu do bazy
            return View(nowyProjekt);

        }
    }
}
    

