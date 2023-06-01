using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektORWeb.Models;
using ProjektORWeb.ViewModels;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//2 commit
namespace ProjektORWeb.Controllers
{
    public class ProjektORController : Controller
    {
        private BzrdDbContext _context;

      
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
            var dbContext = new BzrdDbContext();

            
            var typyProj = dbContext.Typs.ToList();
            var statusProj = dbContext.Statuss.ToList();
            var osobaProj = dbContext.OsobaPracas.ToList();

            var przeslij = new CreateTypsStatusOsoba();

            przeslij.Typ = typyProj;
            przeslij.Status = statusProj;
            przeslij.OsobaProwadzaca = osobaProj;
            przeslij.OsobaZatwierdzajaca = osobaProj;

            return View(przeslij);
        }

        [HttpPost]
        public IActionResult Create(ProjektOR nowyProjekt)
        {
            //Walidacja
            if (ModelState.IsValid) // ==True
            {
                //zapis do bazy danych
                var dbContext = new BzrdDbContext(); //polaczenie z bazą
                //var numer = nowyProjekt.NumerProjektu;
                //Console.WriteLine(nowyProjekt.NumerProjektu);
                //var rok = nowyProjekt.Rok;
                //var dataWplywu = nowyProjekt.DataWplywu;
                //var uwagi = nowyProjekt.Uwagi;
                //var typ = nowyProjekt.Typ;
                //var osobaProwadzaca = nowyProjekt.OsobaProwadzaca;
                //var status = nowyProjekt.Status;

                //var przeslij = new ProjektOR();
                //przeslij.NumerProjektu = numer;


                dbContext.ProjektOrs.Add(nowyProjekt); // dodanie do kolekcji projektów moje pola 
                dbContext.SaveChanges(); // wstawienie rekordu do bazy danych                                         
                return RedirectToAction("PokazProjekty"); //powrot do listy projektow
            }     
            
            return Redirect("Create");
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

        public IActionResult PokazPracownikow ()
        {
            var dbContext = new BzrdDbContext();
            var osoba = dbContext.OsobaPracas;
            var wydzial = dbContext.Wydzials;
            var stanowisko = dbContext.Stanowiskoss;

            var przekazpracownikow = osoba
                                     .Join(wydzial, o => o.Wydzial, w => w.id,
                                     (o, w) => new { o, w })
                                     .Join(stanowisko, os => os.o.Stanowisko, stan => stan.Id,
                                     (os, stan) => new { os, stan })
                                     .Select(all => new OsobaStanowiskoWydzial                    //----ViewModel
                                     {
                                         Identyfikator = all.os.o.id,
                                         Imie = all.os.o.Imie,
                                         Nazwisko = all.os.o.Nazwisko,
                                         DataZatrudnienia = all.os.o.DataZatrudnienia,
                                         DataOdejscia = all.os.o.DataOdejsciazPracy,
                                         Symbol = all.os.o.Symbol,
                                         Wydzial = all.os.w.Nazwa,
                                         Stanowisko = all.stan.Nazwa,
                                         Email = all.os.o.Email
                                     })
                                     .ToList();


            //var przekazpracownikow = dbContext.OsobaPracas                // problem w wyświeltaniem listy
            //                                  .Select(os => new
            //                                  {
            //                                      id = os.id,
            //                                      Imie = os.Imie,
            //                                      Nazwisko = os.Nazwisko,
            //                                      DataZatrudnienia = os.DataZatrudnienia,
            //                                      DataOdejsciazPracy = os.DataOdejsciazPracy,
            //                                      Symbol = os.Symbol,
            //                                      Wydzial = os.WydzialNav.Nazwa,
            //                                      Stanowisko = os.StanowiskoNav.Nazwa,
            //                                      Email = os.Email
            //                                  }).ToList();
            return View(przekazpracownikow);
        }


        public IActionResult CreatePracownik()
        {
            var dbContext = new BzrdDbContext();

            var osobaStanowisko = dbContext.Stanowiskoss.ToList();
            var osobaWydzial = dbContext.Wydzials.ToList();            

            var przeslij = new CreatePracownik();
            przeslij.Stanowiskos = osobaStanowisko;
            przeslij.Wydzials = osobaWydzial;  
            return View(przeslij);
        }

        [HttpPost]
        public IActionResult CreatePracownik(OsobaPraca nowyPracownik)
        {
            if (ModelState.IsValid) // ==True
            {
                //zapis do bazy danych
                var dbContext = new BzrdDbContext(); 
                dbContext.OsobaPracas.Add(nowyPracownik);  
                dbContext.SaveChanges(); // wstawienie rekordu do bazy danych                                         
                return RedirectToAction("PokazPracownikow"); //powrot do listy pracownikow
            }
            return View(nowyPracownik);
        }

        //get EDIT
        public IActionResult EditPracownik(int? id)
        {
            var dbContext = new BzrdDbContext();            
            var pobierzPracownika = dbContext.OsobaPracas.Where(pr => pr.id == id).FirstOrDefault();                  
            return View(pobierzPracownika);
        }

        //post EDIT
        [HttpPost]
        
        public IActionResult EditPracownik(int id, [Bind("id,Imie,Nazwisko,DataZatrudnienia,DataOdejsciazPracy,Symbol,Wydzial,Stanowisko,Email")] OsobaPraca osobaPraca)
        {
            
            if (ModelState.IsValid)
            {
                var dbContext = new BzrdDbContext();
                dbContext.Update(osobaPraca);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(PokazPracownikow));
            }
            return View(osobaPraca);
        }
        




        public IActionResult DiagramEncji()
        {        

            return View();
                      
            
        }
    }
}
    

