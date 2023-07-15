namespace eShield_API.DTOs
{
    public class ExamDTO
    {
        private int _id;

        public ExamDTO(int createdBy, int courseId, DateTime examDate, TimeSpan startTime, TimeSpan endTime)
        {
            CreatedBy = createdBy;
            CourseId = courseId;
            ExamDate = examDate;
            StartTime = startTime;
            EndTime = endTime;
        }

        public int Id { get => _id; set => _id = value; }

        public int CreatedBy { get; set; }

        public int CourseId { get; set; }

        public DateTime ExamDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
