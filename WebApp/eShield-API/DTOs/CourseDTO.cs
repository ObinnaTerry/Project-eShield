using eShield.CoreData.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eShield_API.DTOs
{
    public class CourseDTO
    {

        private int _id;

        private string? courseName;

        public CourseDTO(int id, string courseName)
        {
            _id = id;
            CourseName = courseName;
        }

        public string? CourseName { get => courseName; set => courseName = value; }
        public int Id { get => _id; set => _id = value; }
    }
}


