using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace Tax_Calculator_MVC.Controllers
{
    public class TestHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(string name, int num = 1)
        {
            ViewData["Name"] = name;
            ViewData["Num"] = num;
            return View();
        }
    }
}
