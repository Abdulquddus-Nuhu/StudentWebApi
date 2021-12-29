using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.Models.Payload
{
    public class StudentPayload
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? Surname { get; set; }
        [Required]
        public GenderType Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
