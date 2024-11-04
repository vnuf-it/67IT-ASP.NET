using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class StudentViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChiTiet()
        {
            return View();
        }

        public IActionResult ThemMoi()
        {
            return View();
        }

        public IActionResult ChinhSua()
        {
            return View();
        }
    }
}
