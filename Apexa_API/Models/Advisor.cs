using Apexa_API.Enum;

namespace Apexa_API.Models
{
    public class Advisor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SocialInsuranceNumber { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public HealthStatus HealthStatus { get; set; }
    }
}
