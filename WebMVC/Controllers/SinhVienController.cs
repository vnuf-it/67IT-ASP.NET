using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly SinhVienActions _svActions;

        public SinhVienController()
        {
            _svActions = new SinhVienActions(); // Khởi tạo SinhVienActions
        }

        public IActionResult Index()
        {
            var dsSinhVien = _svActions.GetAll(); // Lấy tất cả sinh viên
            return View(dsSinhVien); // Trả về view với danh sách sinh viên
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); // Trả về view tạo sinh viên
        }

        [HttpPost]
        public IActionResult Create(SinhVien sv)
        {
            if (ModelState.IsValid)
            {
                _svActions.Add(sv); // Thêm sinh viên
                return RedirectToAction("Index"); // Chuyển hướng về danh sách
            }
            return View(sv); // Trả về view nếu có lỗi
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var sinhVien = _svActions.GetByID(id);
            if (sinhVien == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy
            }
            return View(sinhVien); // Trả về view chỉnh sửa sinh viên
        }

        [HttpPost]
        public IActionResult Edit(SinhVien sv)
        {
            if (ModelState.IsValid)
            {
                _svActions.Update(sv); // Cập nhật sinh viên
                return RedirectToAction("Index"); // Chuyển hướng về danh sách
            }
            return View(sv); // Trả về view nếu có lỗi
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _svActions.DeleteByID(id); // Xóa sinh viên theo ID
            return RedirectToAction("Index"); // Chuyển hướng về danh sách
        }

        [HttpPost]
        public IActionResult DeleteAll()
        {
            _svActions.DeleteAll(); // Xóa tất cả sinh viên
            return RedirectToAction("Index"); // Chuyển hướng về danh sách
        }
    }
}
