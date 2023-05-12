using Microsoft.AspNetCore.Mvc;
using ProjektORWeb.Models;

namespace ProjektORWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            Login model = new Login();
            return View();
        }

        

        [HttpPost]
        public IActionResult Index(Login model)
        {
            if (model.Login1 == "admin" || model.Password1 == "admin1")
            {
                return Redirect("http://localhost:5272/Projektor");
            }
            
         return View("BadLog");           
            
        }

        
    }
}
