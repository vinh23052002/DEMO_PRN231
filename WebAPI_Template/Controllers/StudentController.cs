using Microsoft.AspNetCore.Mvc;
using WebAPI_Template.Models;

namespace WebAPI_Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // Tao dang sach student
        private List<Students> data = new List<Students>() {
            new Students("SV01", "Nguyen Van A", 20),
            new Students("SV02", "Nguyen Van B", 21),
            new Students("SV03", "Nguyen Van C", 22),
            new Students("SV04", "Nguyen Van D", 23),
        };

        // GEt: api/Student
        [HttpGet]
        public IActionResult GetAllStudetn()
        {
            return Ok(data);
        }

        [HttpGet]
        [Route("{code}")]
        public IActionResult GetStudentByCode(string code)
        {
            return Ok(data.Find(data => data.Code == code));
        }

        [HttpPost]
        public IActionResult InsertStudent(Students student)
        {
            var s = data.SingleOrDefault(x => x.Code.Equals(student.Code));
            if (s != null)
            {
                return BadRequest();
            }
            data.Add(student);
            return Ok(data);
        }

        [HttpPut]
        public IActionResult UpdateStudent(Students student)
        {
            var s = data.SingleOrDefault(x => x.Code.Equals(student.Code));
            if (s == null)
            {
                return BadRequest();
            }
            Students studentNeedUpdate = data.FirstOrDefault(p => p.Code.Equals(student.Code));
            studentNeedUpdate.Name = student.Name;
            studentNeedUpdate.Age = student.Age;
            return Ok(data);
        }

        [HttpDelete]
        public IActionResult DeleteStudent(string code)
        {
            var s = data.SingleOrDefault(x => x.Code.Equals(code));
            if (s == null)
            {
                return BadRequest();
            }
            Students student = data.FirstOrDefault(p => p.Code.Equals(code));
            data.Remove(student);
            return Ok(data);
        }
    }
}