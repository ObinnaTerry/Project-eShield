namespace eShield_API.DTOs
{
    public class VisitedSiteDTO
    {
        private string _website = null!;
        private DateTime _createTime;

        public VisitedSiteDTO(string website, DateTime createTime)
        {
            _website = website;
            _createTime = createTime;
        }

        public string Website { get => _website; set => _website = value; }
        public DateTime CreateTime { get => _createTime; set => _createTime = value; }
    }
}
