using eShield.CoreData.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eShield_API.DTOs
{
    public class CourseDTO
    {

        public int _id;

        public string? _courseName;

        public CourseDTO(int id, string courseName)
        {
            _id = id;
            _courseName = courseName;
        }
        public int Id { get; set; }

        public string? CourseName { get; set; }
    }
}


