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
            //1. polaczenie do bazy
            var dbContext = new Models.BzrdDbContext();
            
            //2. co zwracam
            var projProj = dbContext.ProjektOrs
                                        .Where(p1 => string.IsNullOrWhiteSpace(query) || (p1.Uwagi).Contains(query))
                                        .ToList();
            var typyProj = dbContext.Typs.ToList();
            var statusProj = dbContext.Statuss.ToList();
            var osobaProj = dbContext.OsobaPracas.ToList();

            //3. ViewModel - kontener
            var pokazAll = new TypsProjektStatusOsobaViewModel();
            pokazAll.ProjektORs = projProj;
            pokazAll.Typs = typyProj;
            pokazAll.Statuses = statusProj;
            pokazAll.osobaPracas = osobaProj;
            pokazAll.Query = query;


            return View(pokazAll);
            
                //var projektTyp = new TypsProjektStatusOsobaViewModel();
                //projektTyp.ProjektORs = projProj;
                //projektTyp.Typs = typyProj;
                //projektTyp.Statuses = statusProj;

                //return View(projektTyp);
            
        }
        public IActionResult Details(int id)
        {
            var dbContext = new BzrdDbContext();
            
            var projProj = dbContext.ProjektOrs;
            var typProj = dbContext.Typs;
            var pracProj = dbContext.OsobaPracas;

            var przekazProjekty = projProj
                                .Join(typProj, pp => pp.Typ, tt => tt.Id,
                                (pp, tt) => new {pp, tt})
                                .Join(pracProj, prac => prac.pp.OsobaProwadzaca, praco => praco.id,
                                (prac, praco) =>new {prac, praco})
                                .Select( all => new DetailsProjektViewModel
                                {
                                    Identyfikator = all.prac.pp.Id,
                                    NrProjektu = all.prac.pp.NumerProjektu,
                                    Rok = all.prac.pp.Rok,
                                    Typ = all.prac.tt.Typ,
                                    OsobaProwImie = all.praco.Imie,
                                    OsobaProwNazw = all.praco.Nazwisko,
                                    EmailProwadzacego = all.praco.Email
                                })
                                .Where(projProj => projProj.Identyfikator == id)
                                .ToList();               

            return View(przekazProjekty);

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
                return RedirectToAction("PokazProjekty"); //powrot do listy projektow
            }                    
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
    

