using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebMVC.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{

    [Route("api/student")] //     [Route("api/[controller]")]

    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly SinhVienActions _svActions;

        public StudentAPIController()
        {
            _svActions = new SinhVienActions(); // Khởi tạo SinhVienActions
        }

        // GET: api/<StudentController>
        [HttpGet]
        public string Get()
        {
            var dsSinhVien = _svActions.GetAll(); // Lấy tất cả sinh viên
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string strJson = JsonSerializer.Serialize<IList<SinhVien>>(dsSinhVien, opt);
            return strJson;
        }

        [HttpGet("sort")]
        public string GetSorted(string sortBy, string order = "asc")
        {
            var dsSinhVien = _svActions.GetAll(); // Lấy tất cả sinh viên

            if (!string.IsNullOrEmpty(sortBy))
            {
                // Lấy kiểu dữ liệu của thuộc tính được chỉ định để sắp xếp
                var propertyType = typeof(SinhVien).GetProperty(sortBy).PropertyType;
                // Kiểm tra xem thuộc tính có phải là chuỗi không
                var isString = propertyType == typeof(string);
                // Kiểm tra xem thứ tự sắp xếp có phải là giảm dần không
                var isDesc = order.ToLower() == "des";

                // Thực hiện sắp xếp dựa trên các điều kiện trên
                dsSinhVien = isDesc
                    ? isString
                        // Nếu giảm dần và thuộc tính là chuỗi, sắp xếp giảm dần theo chuỗi
                        ? dsSinhVien.OrderByDescending(sv => sv.GetType().GetProperty(sortBy).GetValue(sv).ToString()).ToList()
                        // Nếu giảm dần và thuộc tính không phải là chuỗi, sắp xếp giảm dần theo số
                        : dsSinhVien.OrderByDescending(sv => Convert.ToDouble(sv.GetType().GetProperty(sortBy).GetValue(sv))).ToList()
                    : isString
                        // Nếu tăng dần và thuộc tính là chuỗi, sắp xếp tăng dần theo chuỗi
                        ? dsSinhVien.OrderBy(sv => sv.GetType().GetProperty(sortBy).GetValue(sv).ToString()).ToList()
                        // Nếu tăng dần và thuộc tính không phải là chuỗi, sắp xếp tăng dần theo số
                        : dsSinhVien.OrderBy(sv => Convert.ToDouble(sv.GetType().GetProperty(sortBy).GetValue(sv))).ToList();
            }

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string strJson = JsonSerializer.Serialize<IList<SinhVien>>(dsSinhVien, opt);
            return strJson;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var sv = _svActions.GetByID(id); // Lấy tất cả sinh viên
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string strJson = JsonSerializer.Serialize<SinhVien>(sv, opt);
            return strJson;
        }

        // POST api/<StudentController>
        //[HttpPost]
        //public IActionResult Post([FromBody] SinhVien sv)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _svActions.Add(sv);
        //    return CreatedAtAction(nameof(Get), new { id = sv.Tt }, sv);
        //}


        // POST (CÁCH 2)
        [HttpPost]
        public string Post([FromBody] SinhVien sv)
        {
            if (!ModelState.IsValid)
            {
                return JsonSerializer.Serialize(new { error = "Invalid model state" });
            }

            _svActions.Add(sv);
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize(sv, opt);
        }

        // PUT api/<StudentController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] SinhVien sv)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var existing_sv = _svActions.GetByID(id);
        //    if (existing_sv == null)
        //    {
        //        return NotFound(new { error = "SinhVien not found" });
        //    }

        //    // Update the existing SinhVien with new values
        //    existing_sv.Tt = sv.Tt;
        //    existing_sv.Hodem = sv.Hodem;
        //    existing_sv.Ten = sv.Ten;
        //    existing_sv.Cccd = sv.Cccd;
        //    existing_sv.Nickname = sv.Nickname;
        //    existing_sv.Email = sv.Email;
        //    existing_sv.Dienthoai = sv.Dienthoai;
        //    existing_sv.Diem_tichluy = sv.Diem_tichluy;
        //    existing_sv.Diem_renluyen = sv.Diem_renluyen;
        //    // Add other properties as needed

        //    _svActions.Update(existing_sv);

        //    return NoContent(); // 204 No Content
        //}


        // PUT (Cách 2)
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] SinhVien sv)
        {
            if (!ModelState.IsValid)
            {
                return JsonSerializer.Serialize(new { error = "Invalid model state" });
            }

            var existing_sv = _svActions.GetByID(id);
            if (existing_sv == null)
            {
                return JsonSerializer.Serialize(new { error = "SinhVien not found" });
            }

            // Update the existing SinhVien with new values
            existing_sv.Tt = sv.Tt;
            existing_sv.Hodem = sv.Hodem;
            existing_sv.Ten = sv.Ten;
            existing_sv.Cccd = sv.Cccd;
            existing_sv.Nickname = sv.Nickname;
            existing_sv.Email = sv.Email;
            existing_sv.Dienthoai = sv.Dienthoai;
            existing_sv.Diem_tichluy = sv.Diem_tichluy;
            existing_sv.Diem_renluyen = sv.Diem_renluyen;
            // Add other properties as needed

            _svActions.Update(existing_sv);

            return JsonSerializer.Serialize(new { message = "Update successful" });
        }


        // DELETE api/<StudentController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var existing_sv = _svActions.GetByID(id);
        //    if (existing_sv == null)
        //    {
        //        return NotFound(new { error = "SinhVien not found" });
        //    }

        //    _svActions.DeleteByID(id);

        //    return NoContent(); // 204 No Content
        //}

        // DELETE (Cách 2)
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var existing_sv = _svActions.GetByID(id);
            if (existing_sv == null)
            {
                return JsonSerializer.Serialize(new { error = "SinhVien not found" });
            }

            _svActions.DeleteByID(id);

            return JsonSerializer.Serialize(new { message = "Delete successful" });
        }

        [HttpDelete]
        public string DeleteAll()
        {
            var allSinhViens = _svActions.GetAll();
            if (allSinhViens == null || !allSinhViens.Any())
            {
                return JsonSerializer.Serialize(new { message = "No SinhVien records to delete" });
            }

            foreach (var sv in allSinhViens)
            {
                _svActions.DeleteAll();
            }

            return JsonSerializer.Serialize(new { message = "All SinhVien records deleted successfully" });
        }
    }
}
