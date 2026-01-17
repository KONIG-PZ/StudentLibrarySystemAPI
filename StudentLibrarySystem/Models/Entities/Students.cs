using System.ComponentModel.DataAnnotations;

namespace StudentLibrarySystem.Models.Entities
{
    public class Students
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public required string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        [Range(1, 12)]
        public required int GradeLevel { get; set; }

    }
}
