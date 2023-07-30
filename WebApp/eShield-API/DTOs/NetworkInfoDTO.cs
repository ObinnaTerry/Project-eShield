using eShield.CoreData.Entities;
using System.ComponentModel.DataAnnotations;

namespace eShield_API.DTOs
{
    public class NetworkInfoDTO
    {
        public int Id { get; set; }

        [Required]
        public string StudentEmail { get; set; } = null!;

        [Required]
        public string Examcode { get; set; } = null!;

        [Required]
        public string Ipaddress { get; set; } = null!;

        [Required]
        public string Macaddress { get; set; } = null!;
    }
}
