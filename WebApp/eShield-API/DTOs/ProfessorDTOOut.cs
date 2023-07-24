using eShield.CoreData.Entities;

namespace eShield_API.DTOs
{
    public class ProfessorDTOOut
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int CourseId { get; set; }

        public virtual CourseDTO Course { get; set; } = null!;

        public virtual ICollection<ExamDTO> Exams { get; set; } = new List<ExamDTO>();
    }
}
