﻿using eShield.CoreData.Entities;
using eShield.CoreData.Interfaces;
using eShield_API.DTOs;

namespace eShield_API.DataService
{
    public class ProfessorDataService
    {
        private readonly IProfessorRepo _professorRepo;

        public ProfessorDataService(IProfessorRepo professorRepo)
        {
            _professorRepo = professorRepo;
        }

        public ProfessorDTOOut Create(ProfessorDTOIn professorDTOIn)
        {
            Professor professor = new Professor
            {
                FirstName = professorDTOIn.FirstName,
                LastName = professorDTOIn.LastName,
                Email = professorDTOIn.Email,
                CourseId = professorDTOIn.CourseId,
            };

            _professorRepo.Insert(professor);
            _professorRepo.Save();

            return new ProfessorDTOOut
            {
                Id = professor.Id,
                LastName = professor.LastName,
                Email = professor.Email,
                FirstName = professor.FirstName,
                CourseId = professor.CourseId
            };
        }

        public async Task<ProfessorDTOOut?> ReadByIdAync(int id)
        {
            Professor? professor = await _professorRepo.GetByIDAsync(id);

            if (professor == null)
            {
                return null;
            }

            return new ProfessorDTOOut
            {
                Id = id,
                LastName = professor.LastName,
                Email = professor.Email,
                FirstName = professor.FirstName,
                CourseId = professor.CourseId,
                Course = professor.Course != null ? new CourseDTO(professor.Course.Id, professor.Course.CourseName) : null,
                Exams = professor.Exams.Select(exam => 
                new ExamDTO(exam.CreatedBy, exam.CourseId, exam.ExamDate, exam.StartTime, exam.EndTime)
                ).ToList()
            };
        }

        public List<ProfessorDTOOut> ReadAll()
        {
            IQueryable<Professor> professors = _professorRepo.GetAll();

            List<ProfessorDTOOut> professorDTOOuts = new List<ProfessorDTOOut>();

            foreach (var professor in professors)
            {
                professorDTOOuts.Add(new ProfessorDTOOut { 
                    Id = professor.Id, 
                    LastName = professor.LastName, 
                    Email = professor.Email,
                    FirstName = professor.FirstName,
                    CourseId = professor.CourseId,
                    Course = professor.Course != null ? new CourseDTO(professor.Course.Id, professor.Course.CourseName) : null,
                    Exams = professor.Exams.Select(exam => 
                    new ExamDTO(exam.CreatedBy, exam.CourseId, exam.ExamDate, exam.StartTime, exam.EndTime)
                    ).ToList()
                });
            }

            return professorDTOOuts;
        }

        public async Task UpdateAsync(int id, ProfessorDTOIn professorDTOIn)
        {
            Professor? professor = await _professorRepo.GetByIDAsync(id);

            if (professor == null)
            {
                return;
            }

            professor.Email = professorDTOIn.Email;
            professor.LastName = professorDTOIn.LastName;
            professor.FirstName = professorDTOIn.FirstName;
            professor.CourseId = professorDTOIn.CourseId;

            _professorRepo.Update(professor);
            _professorRepo.Save();
        }

        public void Delete(int id)
        {
            _professorRepo.Delete(id);
            _professorRepo.Save();
        }
    }
}
