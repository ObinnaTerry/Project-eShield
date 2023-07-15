using eShield.CoreData.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eShield_API.DTOs
{
    public class CourseDTO
    {

        public int _id;

        public string _courseName;

        public int _professorId;

        public CourseDTO(int id, string courseName, int professorId)
        {
            _id = id;
            _courseName = courseName;
            _professorId = professorId;
        }
        public int Id { get; set; }

        public string CourseName { get; set; }

        public int ProfessorId { get; set; }

    }
}


