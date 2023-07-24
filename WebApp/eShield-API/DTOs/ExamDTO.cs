namespace eShield_API.DTOs
{
    public class ExamDTO
    {
        private int _id;
        private int _createdBy;
        private int _courseId;
        private DateTime _examDate;
        private TimeSpan _startTime;
        private TimeSpan _endTime;

        public ExamDTO(int createdBy, int courseId, DateTime examDate, TimeSpan startTime, TimeSpan endTime)
        {
            _createdBy = createdBy;
            _courseId = courseId;
            _examDate = examDate;
            _startTime = startTime;
            _endTime = endTime;
        }

        public int Id { get => _id; set => _id = value; }

        public int CreatedBy { get => _createdBy; set => _createdBy = value; }

        public int CourseId { get => _courseId; set => _courseId = value; }

        public DateTime ExamDate { get => _examDate; set => _examDate = value; }

        public TimeSpan StartTime { get => _startTime; set => _startTime = value; }

        public TimeSpan EndTime { get => _endTime; set => _endTime = value; }
    }
}
