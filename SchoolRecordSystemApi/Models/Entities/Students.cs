using System.ComponentModel.DataAnnotations;

namespace SchoolRecordSystemApi.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public required string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Section { get; set; }
        [Range(1, 12)]
        public required int GradeLevel { get; set; }
        [MaxLength(100)]
        public string Subject { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
    }
}
