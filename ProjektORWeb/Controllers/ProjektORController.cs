using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektORWeb.Models;
using ProjektORWeb.ViewModels;
using System;

//2 commit
namespace ProjektORWeb.Controllers
{
    public class ProjektORController : Controller
    {

        public IActionResult Index()
        {
            try
            {
                
                var dbContext = new BzrdDbContext();
                var czyJestWierszTyp = dbContext.Typs.FirstOrDefault();
                

            }
            catch
            {
                
                Constans.ConnectionString = "";
                return Redirect("/");
            }
            return View();
        }




        public IActionResult Opcje()
        {

            return View();
        }

        public IActionResult PokazProjekty(string query) //parametr query pochodzi z metody GET - szukaj
        {
            
            var dbContext = new Models.BzrdDbContext();

            var projProj = dbContext.ProjektOrs.ToList();
            var typyProj = dbContext.Typs.ToList();
            var statusProj = dbContext.Statuss.ToList();
            var osobaProj = dbContext.OsobaPracas.ToList(); 

            var projektTyp = new TypsProjektStatusOsobaViewModel();
            projektTyp.ProjektORs = projProj;
            projektTyp.Typs = typyProj;
            projektTyp.Statuses = statusProj;
            projektTyp.osobaPracas = osobaProj;



            //var result = projektTyp.Typs.Join(projektTyp.ProjektORs)
            //                      .Where(st => st.Uwagi =="3");


            //var result = from col1 in dbContext.ProjektOrs
            //             join col2 in dbContext.TypsProjektViewModel
            //             where col1.Typ == col2.Id
            //             select new TypsProjektViewModel
            //             {
            //                 ProjektORs = col2.Typ,
            //                 Typs = col1.NumerProjektu 
            //             };

           
            //var projekty = dbContext.ProjektOrs
            //                            .Where(p1 => string.IsNullOrWhiteSpace(query) || (p1.Uwagi).Contains(query))
            //                            .ToList();


            return View(projektTyp);





        }
        public IActionResult Details(int id)
        {
            var dbContext = new BzrdDbContext();
            var projProj = dbContext.ProjektOrs.ToList();            
            var osobaProj = dbContext.OsobaPracas.ToList();

            var detale = new TypsProjektStatusOsobaViewModel();
            detale.ProjektORs = projProj;
            detale.osobaPracas = osobaProj;



            return View(detale);

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


        public IActionResult Delete(int id)
        {
            var BzrdDbContext = new Models.BzrdDbContext();  //połączenie
            var projektToDelete = new ProjektOR();          //stworz obiekt projekt
            projektToDelete.Id = id;                        //przypisz mu Id , ktore dostanie z widoku

            BzrdDbContext.ProjektOrs.Attach(projektToDelete);   //add by dodał attach mowi ze on juz istnieje i go nie dodaje (musi zaistnień projekt w tym kontekscie)
            BzrdDbContext.ProjektOrs.Remove(projektToDelete);   //wyslij do bazy przez dbContext żadanie usunięcia projektu z kolekcji projektów
            BzrdDbContext.SaveChanges();
            return RedirectToAction("PokazProjekty");
        }


        public IActionResult DiagramEncji()
        {

            return View();
            
        }
    }
}
    

