using eShield.CoreData.Entities;
using eShield.CoreData.Interfaces;
using eShield_API.DTOs;

namespace eShield_API.DataService
{
    public class ExamDataService
    {
        private readonly IExamRepo _examRepo;
        private readonly IExamCodeRepo _examCodeRepo;

        public ExamDataService(IExamRepo examRepo, IExamCodeRepo examCodeRepo)
        {
            _examRepo = examRepo;
            _examCodeRepo = examCodeRepo;
        }

        public Exam Create(ExamDTO examDTO)
        {
            Exam exam = new Exam
            {
                CourseId = examDTO.CourseId,
                StartTime = examDTO.StartTime,
                EndTime = examDTO.EndTime,
                CreatedBy = examDTO.CreatedBy,
                ExamDate = examDTO.ExamDate
            };

            _examRepo.Insert(exam);
            _examRepo.Save();

            string code = exam.Id + Utils.ExamCode.GenerateCode();

            ExamCode examCode = new ExamCode
            {
                Code = code,
                ExamId = exam.Id
            };

            _examCodeRepo.Insert(examCode);
            _examCodeRepo.Save();

            return exam;
        }

        public List<ExamDTO> ReadAll(int profId)
        {

            IQueryable<Exam> exams = _examRepo.GetAll().Where(x => x.CreatedBy == profId);

            List<ExamDTO> examDTOs = new List<ExamDTO>();

            foreach (var exam in exams)
            {
                ExamDTO examDTO = new ExamDTO(exam.CreatedBy, exam.CourseId, exam.ExamDate, exam.StartTime, exam.EndTime)
                {
                    Id = exam.Id
                };

                examDTOs.Add(examDTO);
            }

            return examDTOs;
        }

        public async Task<ExamDTO?> ReadById(int id)
        {
            Exam? exam = await _examRepo.GetByIDAsync(id);

            if (exam == null)
            {
                return null;
            }

            ExamDTO examDTO = new ExamDTO(exam.CreatedBy, exam.CourseId, exam.ExamDate, exam.StartTime, exam.EndTime)
            { 
                Id = exam.Id
            };

            return examDTO;
        }

        public async Task<Exam> Update(int id, ExamDTO examDTO)
        {
            Exam? exam = await _examRepo.GetByIDAsync(id);

            exam!.ExamDate = examDTO.ExamDate;
            exam.StartTime = examDTO.StartTime;
            exam.CourseId = examDTO.CourseId;
            exam.EndTime = examDTO.EndTime;

            _examRepo.Update(exam);
            _examRepo.Save();

            return exam;
        }

        public void Delete(int id)
        {
            _examRepo.Delete(id);
        }
    }
}
