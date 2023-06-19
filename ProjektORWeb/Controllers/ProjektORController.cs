using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektORWeb.Models;
using ProjektORWeb.ViewModels;
using System;
using System.Collections.Immutable;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                                        .Include(c => c.ZarzadcaDrogisId) // JOIN do asocjacji oraz Zarzadca Drogi pobierz projekty 
                                        .Where(p1 => string.IsNullOrWhiteSpace(query) || (p1.Uwagi).Contains(query))
                                        .ToList();

            

            foreach(var p in projProj)
            {
                string zarzadcy = "";
                foreach(var z in p.ZarzadcaDrogisId)
                {
                    zarzadcy+= " "+z.Nazwa;
                }
                p.Zarzadcy = zarzadcy;
            }

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

        //Create Projekt
        public IActionResult Create() 
        {
            var dbContext = new BzrdDbContext();

            
            var typyProj = dbContext.Typs.ToList();
            var statusProj = dbContext.Statuss.ToList();
            var osobaProj = dbContext.OsobaPracas.ToList();

            var przeslij = new CreateTypsStatusOsoba();

            przeslij.Typ = typyProj; ;
            przeslij.Status = statusProj;
            przeslij.OsobaProwadzaca = osobaProj;
            przeslij.OsobaZatwierdzajaca = osobaProj;
           

            return View(przeslij);
        }

        [HttpPost]
        public IActionResult Create(CreateTypsStatusOsoba nowyProjekt) // musi być CreateTypsStatusOsoba?
        {

            ModelState.Remove("Typ");
            ModelState.Remove("OsobaProwadzaca");
            ModelState.Remove("OsobaZatwierdzajaca");
            ModelState.Remove("Status");

            if (ModelState.IsValid) 
            {

                var dbContext = new BzrdDbContext();
                var dodajProjekt = new ProjektOR();
                dodajProjekt.NumerProjektu = nowyProjekt.NumerProjektu;
                dodajProjekt.Rok = nowyProjekt.Rok;
                dodajProjekt.DataWplywu = nowyProjekt.DataWplywu;
                dodajProjekt.Uwagi = nowyProjekt.Uwagi;
                dodajProjekt.Typ = nowyProjekt.TypId;
                dodajProjekt.OsobaProwadzaca = nowyProjekt.OsobaProwadzacaId;
                dodajProjekt.OsobaZatwierdzajaca = nowyProjekt.OsobaZatwierdzajacaId;
                dodajProjekt.Status = nowyProjekt.StatusId;

                dbContext.ProjektOrs.Add(dodajProjekt); // dodanie do kolekcji projektów moje pola 
                dbContext.SaveChanges(); // wstawienie rekordu do bazy danych                                         
                return RedirectToAction("PokazProjekty"); //powrot do listy projektow
                


                
            }     
            else
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
           
        }

        //GET edit Projekt
        public IActionResult EditProjekt(int id)
        {
            var dbContext = new BzrdDbContext();
            var pobierzProjekt = dbContext.ProjektOrs.Where(proj => proj.Id == id).FirstOrDefault();
            var typProj = dbContext.Typs.ToList();
            var statusProj = dbContext.Statuss.ToList();
            var osobaProj = dbContext.OsobaPracas.ToList();

            var przeslij = new EditProjekt();
            
            
            przeslij.Typ = typProj.Select(x => new SelectListItem(x.Typ, x.Id+"")).ToList(); //CAST Listowy
            przeslij.Status = statusProj.Select(x => new SelectListItem(x.Nazwa, x.id + "")).ToList();
            przeslij.OsobaProwadzaca = osobaProj.Select(x => new SelectListItem(x.Nazwisko, x.id + "")).ToList();
            przeslij.OsobaZatwierdzajaca = osobaProj.Select(x => new SelectListItem(x.Nazwisko, x.id + "")).ToList();


            przeslij.NumerProjektu = pobierzProjekt.NumerProjektu;
            przeslij.Rok = pobierzProjekt.Rok;
            przeslij.DataWplywu = pobierzProjekt.DataWplywu;            
            przeslij.StatusId = pobierzProjekt.Status;
            przeslij.OsobaProwadzacaId = pobierzProjekt.OsobaProwadzaca;
            przeslij.OsobaZatwierdzajacaId = pobierzProjekt.OsobaZatwierdzajaca;
            przeslij.TypId = pobierzProjekt.Typ;

            return View(przeslij);
            
        }

        //POST edit Projekt
        [HttpPost]
        public IActionResult EditProjekt(EditProjekt editProjekt)
        {
            ModelState.Remove("Typ");// usuniecie walidacji z ViewModel
            ModelState.Remove("Status");// usuniecie walidacji z ViewModel
            ModelState.Remove("OsobaProwadzaca");// usuniecie walidacji z ViewModel
            ModelState.Remove("OsobaZatwierdzajaca");// usuniecie walidacji z ViewModel

            if (ModelState.IsValid)
            {

                var dbContext = new BzrdDbContext();
                var przeslij = new ProjektOR();
                przeslij.Id = editProjekt.id;
                przeslij.NumerProjektu = editProjekt.NumerProjektu;
                przeslij.Rok = editProjekt.Rok;
                przeslij.DataWplywu = editProjekt.DataWplywu;
                przeslij.Uwagi = editProjekt.Uwagi;
                przeslij.Typ = editProjekt.TypId;
                przeslij.OsobaProwadzaca = editProjekt.OsobaProwadzacaId;
                przeslij.Status = editProjekt.StatusId;
                przeslij.OsobaZatwierdzajaca = editProjekt.OsobaZatwierdzajacaId;


                dbContext.Update(przeslij);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(PokazProjekty));
            }
            else
            {
                var dbContext = new BzrdDbContext();
                
                var typProj = dbContext.Typs.ToList();
                var statusProj = dbContext.Statuss.ToList();
                var osobaProj = dbContext.OsobaPracas.ToList();

                var przeslij = new EditProjekt();


                przeslij.Typ = typProj.Select(x => new SelectListItem(x.Typ, x.Id + "")).ToList(); //CAST Listowy
                przeslij.Status = statusProj.Select(x => new SelectListItem(x.Nazwa, x.id + "")).ToList();
                przeslij.OsobaProwadzaca = osobaProj.Select(x => new SelectListItem(x.Nazwisko, x.id + "")).ToList();
                przeslij.OsobaZatwierdzajaca = osobaProj.Select(x => new SelectListItem(x.Nazwisko, x.id + "")).ToList();

                return View(przeslij);
            }
            
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
        public IActionResult CreatePracownik(CreatePracownik nowyPracownik)
        {
            ModelState.Remove("Wydzials");
            ModelState.Remove("Stanowiskos");
            if (ModelState.IsValid) // ==True
            {
                //zapis do bazy danych
                var dbContext = new BzrdDbContext();
                var dodajOsoba = new OsobaPraca();
                dodajOsoba.Imie = nowyPracownik.Imie;
                dodajOsoba.Nazwisko = nowyPracownik.Nazwisko;
                dodajOsoba.DataZatrudnienia = nowyPracownik.DataZatrudnienia;
                dodajOsoba.DataOdejsciazPracy = nowyPracownik.DataOdejsciazPracy;
                dodajOsoba.Symbol = nowyPracownik.Symbol;

                dodajOsoba.Wydzial = nowyPracownik.WydzialId;
                dodajOsoba.Stanowisko = nowyPracownik.StanowiskoId;
                
                dodajOsoba.Email = nowyPracownik.Email;
                dbContext.OsobaPracas.Add(dodajOsoba);  
                dbContext.SaveChanges(); // wstawienie rekordu do bazy danych                                         
                return RedirectToAction("PokazPracownikow"); //powrot do listy pracownikow
            }
            else
            {
                var dbContext = new BzrdDbContext();
                var osobaStanowisko = dbContext.Stanowiskoss.ToList();
                var osobaWydzial = dbContext.Wydzials.ToList();

                var przeslij = new CreatePracownik();
                przeslij.Stanowiskos = osobaStanowisko;
                przeslij.Wydzials = osobaWydzial;



                return View(przeslij);
            }

            
        }

        //get EDIT Pracownik

        public IActionResult EditPracownik(int? id)
        {

            var dbContext = new BzrdDbContext();

            var osobaPraca = dbContext.OsobaPracas.Where(os => os.id == id).FirstOrDefault();
            var osobaStanowisko = dbContext.Stanowiskoss.ToList();
            var osobaWydzial = dbContext.Wydzials.ToList();

            var przeslij = new EditPracownik();
            przeslij.Imie = osobaPraca.Imie;
            przeslij.Nazwisko = osobaPraca.Nazwisko;
            przeslij.DataZatrudnienia = osobaPraca.DataZatrudnienia;
            przeslij.DataOdejsciazPracy = osobaPraca.DataOdejsciazPracy;
            przeslij.Symbol = osobaPraca.Symbol;
            przeslij.Email = osobaPraca.Email;
            przeslij.StanowiskoId = osobaPraca.Stanowisko;
            przeslij.WydzialId = osobaPraca.Wydzial;

            przeslij.Stanowisko = osobaStanowisko.Select(st => new SelectListItem(st.Nazwa, st.Id + "")).ToList();
            przeslij.Wydzials = osobaWydzial.Select(wydz => new SelectListItem(wydz.Nazwa, wydz.id + "")).ToList();
            
            return View(przeslij);

            
        }

        //post EDIT Pracownik
        [HttpPost]        
        public IActionResult EditPracownik(EditPracownik osobaPraca)
        {
            ModelState.Remove("Wydzials");
            ModelState.Remove("Stanowiskos");
            if (ModelState.IsValid)                     
            {
                var dbContext = new BzrdDbContext();
                var dodajOsoba = new OsobaPraca();
                dodajOsoba.id = osobaPraca.Id;
                dodajOsoba.Imie = osobaPraca.Imie;
                dodajOsoba.Nazwisko = osobaPraca.Nazwisko;
                dodajOsoba.DataZatrudnienia = osobaPraca.DataZatrudnienia;
                dodajOsoba.DataOdejsciazPracy = osobaPraca.DataOdejsciazPracy;
                dodajOsoba.Symbol = osobaPraca.Symbol;
                dodajOsoba.Wydzial = osobaPraca.WydzialId;
                dodajOsoba.Stanowisko = osobaPraca.StanowiskoId;
                dodajOsoba.Email = osobaPraca.Email;

                dbContext.Update(dodajOsoba);           
                dbContext.SaveChanges();
                return RedirectToAction(nameof(PokazPracownikow));
            }
            else
            {
                var dbContext = new BzrdDbContext();
                var osobaStanowisko = dbContext.Stanowiskoss.ToList();
                var osobaWydzial = dbContext.Wydzials.ToList();

                var przeslij = new EditPracownik();                
                przeslij.StanowiskoId = osobaPraca.StanowiskoId;
                przeslij.WydzialId = osobaPraca.WydzialId;

                przeslij.Stanowisko = osobaStanowisko.Select(st => new SelectListItem(st.Nazwa, st.Id + "")).ToList();
                przeslij.Wydzials = osobaWydzial.Select(wydz => new SelectListItem(wydz.Nazwa, wydz.id + "")).ToList();

                return View(przeslij);
            }
            
        }
        


        public IActionResult InneTabele()
        {
            var dbContext = new BzrdDbContext();
            var typ = dbContext.Typs.ToList();
            var status = dbContext.Statuss.ToList();   
            var stanowiska = dbContext.Stanowiskoss.ToList();
            var Wydzial = dbContext.Wydzials.ToList();
            

            var przeslij = new InneTabele();
            przeslij.Typs = typ;
            przeslij.Statuses = status;
            przeslij.Stanowiskos = stanowiska;
            przeslij.Wydzials = Wydzial;
            
            return View(przeslij);
        }

        public IActionResult PokazZarzadcow() 
        {
            var dbContext = new BzrdDbContext();
            var zarzadcy = dbContext.zarzadcaDrogis.ToList();
            return View(zarzadcy); 
        }


        public IActionResult DiagramEncji()
        {        

            return View();
                      
            
        }
    }
}
    

