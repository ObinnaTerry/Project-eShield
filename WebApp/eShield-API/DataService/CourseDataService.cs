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
                CourseName = courseDTO.CourseName!,
            };

            _courseRepo.Insert(course);
            _courseRepo.Save();

            return course;
        }

        public CourseDTO?  ReadId(int id)
        {
            Course? course = _courseRepo.GetAll().Where(x => x.Id == id).FirstOrDefault();

            if (course == null)
            {
                return null;
            }

            CourseDTO courseDTO = new CourseDTO(course.Id, course.CourseName);

            return courseDTO;
        }

        public void Delete(int id)
        {
            _courseRepo.Delete(id);
        }

        public void Update(int id, CourseDTO courseDTO)
        {
            Course course = new Course
            {
                Id = id,
                CourseName = courseDTO.CourseName!
            };

            _courseRepo.Update(course);
            _courseRepo.Save();
        }

        public List<CourseDTO> ReadAll()
        {
           IQueryable<Course> courses = _courseRepo.GetAll();

            List<CourseDTO> courseDTOs = new List<CourseDTO>();

            foreach (var course in courses)
            {
                courseDTOs.Add(new CourseDTO(course.Id, course.CourseName));
            }

            return courseDTOs;
        }
     
    }
}

