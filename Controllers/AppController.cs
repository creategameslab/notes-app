using Microsoft.AspNetCore.Mvc;

namespace Notes.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
