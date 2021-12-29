using System;
using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.Models
{
    public class Course
    {
        public Course()
        {
            CourseId = Guid.NewGuid();
        }
        public Guid CourseId { get; set; }
        public string? Name { get; set; }

        //Navigation property
        public ICollection<Student>? Students { get; set; }
    }
}
