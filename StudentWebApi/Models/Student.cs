using System;
using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.Models
{
    public class Student
    {
        public Student()
        {
            StudentId = Guid.NewGuid();
        }
        public Guid StudentId { get; set; }
        public string? FirstName { get; set;}
        public string? Surname { get; set; }
        public string? LastName { get; set;}
        public GenderType Gender  { get; set; }
        public DateTime DateOfBirth { get; set; }

        //Navigation property
        public ICollection<Course>? Courses { get; set; }
    }
}
