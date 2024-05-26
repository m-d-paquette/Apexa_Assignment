using Apexa_API.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apexa_API.Models
{
    public class Advisor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string SocialInsuranceNumber { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public HealthStatus HealthStatus { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
    }
}
