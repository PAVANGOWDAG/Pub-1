using Microsoft.AspNetCore.Mvc;

namespace Pub_Mangement.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
