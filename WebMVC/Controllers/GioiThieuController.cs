using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class GioiThieuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
