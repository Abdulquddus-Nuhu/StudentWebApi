using System;

namespace PostgresWebApi.Models
{
    public class Student
    {
        public Student()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set;}
        public string Surname { get; set; }
        public string LastName { get; set;}
        public GenderType Gender  { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
    }
    public enum GenderType
    {
        Male, Female
    }
}
