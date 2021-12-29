using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.Models.Payload
{
    public class CoursePayload
    {
        [Required]
        public string? Name { get; set; }
    }
}
