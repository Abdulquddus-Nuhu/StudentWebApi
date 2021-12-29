using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Data;
using StudentWebApi.Models;
using StudentWebApi.Models.Payload;

namespace StudentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _dbcontext;
        public StudentController(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateStudent([FromBody] StudentPayload student)
        {
            var tempStudent = new Student()
            {
                DateOfBirth = student.DateOfBirth,
                FirstName = student.FirstName,
                Gender = student.Gender,
                LastName = student.LastName,
                Surname = student.Surname,
            };
            await _dbcontext.Students.AddAsync(tempStudent);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

        //[Route("/CreateStudentCourses/")]
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> CreateStudentCourses([FromBody] Student student)
        //{
        //    var tempStudent = new Student()
        //    {
        //        Courses = student.Courses,
        //        DateOfBirth = student.DateOfBirth,
        //        FirstName = student.FirstName,
        //        Gender = student.Gender,
        //        LastName = student.LastName,
        //        Surname = student.Surname,
        //    };
        //    await _dbcontext.Students.AddAsync(tempStudent);
        //    await _dbcontext.SaveChangesAsync();
        //    return Ok();
        //}

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteStudent(Guid studentId)
        {
            var student = _dbcontext.Students.FirstOrDefault(x => x.StudentId == studentId);

            if (student == null)
                return BadRequest();

            _dbcontext.Students.Remove(student);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetStudent(Guid studentId)
        {
            var student = _dbcontext.Students.FirstOrDefault(x => x.StudentId == studentId);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllStudent()
        {
            var student = _dbcontext.Students.AsQueryable();

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateStudent(Guid studentId, [FromBody] StudentPayload student)
        {
            var studentDb = _dbcontext.Students.AsQueryable();
            var tempStudent = studentDb.Where(s => s.StudentId == studentId).FirstOrDefault();

            if (tempStudent == null)
                return NotFound();
           
            tempStudent.FirstName = student.FirstName;
            tempStudent.LastName = student.LastName;
            tempStudent.Gender = student.Gender;
            tempStudent.DateOfBirth = student.DateOfBirth;
            tempStudent.FirstName = student.FirstName;

            _dbcontext.Students.Update(tempStudent);
            await _dbcontext.SaveChangesAsync();

            return NoContent();
        }
    }
}
