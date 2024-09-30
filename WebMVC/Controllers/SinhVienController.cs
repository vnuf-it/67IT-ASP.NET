using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class SinhVienController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly SinhVienActions _svActions;


        public SinhVienController()
        {
            _svActions = new SinhVienActions();
        }

        public IActionResult GetAll()
        {
            List<SinhVien> ds = _svActions.GetAll();
            return View(ds);
        }
    }
}
