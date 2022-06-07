using Microsoft.AspNetCore.Mvc;

namespace testVul.Controllers
{
    public class Sample1 : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}