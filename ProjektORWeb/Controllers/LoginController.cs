using Microsoft.AspNetCore.Mvc;
using ProjektORWeb.Models;

namespace ProjektORWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            Constans.ConnectionString = "";
            Login model = new Login();
            return View();
        }

        

        [HttpPost]
        public IActionResult Index(Login model)
        {
            try
            {
                Constans.ConnectionStr(model.Login1, model.Password1);
                Console.WriteLine(Constans.ConnectionString);
                var dbContext = new BzrdDbContext();
                var czyJestWierszTyp = dbContext.Typs.FirstOrDefault();
                
                
            }
            catch 
            {
                
                Constans.ConnectionString = "";
                return View("BadLog");
            }


            
            return Redirect("http://localhost:5272/Projektor");



        }

        
    }
}
