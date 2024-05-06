using Microsoft.AspNetCore.Mvc;

namespace JWT_DEMO.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetEmployee()
        {
            return Ok("Employee details");
        }


    }
}
