using eShield.CoreData.Entities;

namespace eShield_API.DTOs
{
    public class ProfessorDTOIn
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
    }
}
