namespace eShield_API.DTOs
{
    public class VisitedSiteDTO
    {
        private int _studentId;
        private int _examId;
        private string _website = null!;
        private DateTime _createTime;
        private int _id;

        public VisitedSiteDTO(int id, int studentId, int examId, string website, DateTime createTime)
        {
            _studentId = studentId;
            _website = website;
            _examId = examId;
            _createTime = createTime;
            _id = id;
        }

        public int Id { get => _id; set => _id = value; }

        public int StudentId { get => _studentId; set => _studentId = value; }

        public int ExamId { get => _examId; set => _examId = value; }

        public string Website { get => _website; set => _website = value; }
        public DateTime CreateTime { get => _createTime; set => _createTime = value; }
    }
}
