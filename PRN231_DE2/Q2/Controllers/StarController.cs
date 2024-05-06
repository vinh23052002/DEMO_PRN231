using Microsoft.AspNetCore.Mvc;

namespace Q2.Controllers
{
    public class StarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
