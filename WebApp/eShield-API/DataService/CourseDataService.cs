using eShield.CoreData.Entities;
using eShield.CoreData.Interfaces;
using eShield_API.DTOs;

namespace eShield_API.DataService
{
    public class CourseDataService
    {
        private readonly ICourseRepo _courseRepo;

        public CourseDataService(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
           
        }

        public Course Create(CourseDTO courseDTO)
        {
            Course course = new Course()
            {
                CourseName = courseDTO.CourseName,
                ProfessorId = courseDTO.ProfessorId
                
            };

            _courseRepo.Insert(course);
            _courseRepo.Save();

            return course;
        }

          public CourseDTO  ReadByProfId(int profid)
        {
            Course? course = _courseRepo.GetAll().Where(x => x.ProfessorId == profid).FirstOrDefault();

            if (course == null)
            {
                return null;
            }

            CourseDTO courseDTO = new CourseDTO(course.Id, course.CourseName, course.ProfessorId);

            return courseDTO;
        }

     
    }
}

