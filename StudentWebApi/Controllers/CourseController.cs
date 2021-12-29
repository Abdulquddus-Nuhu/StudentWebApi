using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Data;
using StudentWebApi.Models;
using StudentWebApi.Models.Payload;
using System;

namespace StudentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext _dbcontext;
        public CourseController(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateCourse([FromBody] CoursePayload course)
        {
            var tempCourse = new Course()
            {
               Name = course.Name,
            };

            await _dbcontext.Courses.AddAsync(tempCourse);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

        //[Route("/CreateCourseStudents/")]
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> CreateCourseStudent([FromBody] Course course)
        //{
        //    var tempCourse = new Course()
        //    {
        //       Students = course.Students,
        //       Name = course.Name,
        //    };

        //    await _dbcontext.Courses.AddAsync(tempCourse);
        //    await _dbcontext.SaveChangesAsync();
        //    return Ok();
        //}

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllCourse()
        {
            var courses = _dbcontext.Courses.AsQueryable();

            return Ok(courses);
        }
    }
}
