using System.Text.Json.Serialization;

namespace eShield_API.DTOs
{
    public class VisitedSiteDashboardDTO
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public double Timelapse { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
