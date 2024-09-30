using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class TinTucController : Controller
    {
        public IActionResult DienTu()
        {
            return View();
        }

        public IActionResult BongDa()
        {
            return View();
        }

        public IActionResult QuanVot()
        {
            return View();
        }
    }
}
