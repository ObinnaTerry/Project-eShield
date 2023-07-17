namespace eShield_API.DTOs
{
    public class ProfessorDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int CourseId { get; set; }
    }
}
