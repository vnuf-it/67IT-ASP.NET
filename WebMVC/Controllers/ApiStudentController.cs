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
        //    existing_sv.Hodem = existing_sv.Hodem;
        //    existing_sv.Ten = existing_sv.Ten;
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
            existing_sv.Hodem = sv.Hodem;
            existing_sv.Ten = sv.Ten;
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
