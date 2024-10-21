using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebMVC.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SinhVienActions _svActions;

        public StudentController()
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
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
