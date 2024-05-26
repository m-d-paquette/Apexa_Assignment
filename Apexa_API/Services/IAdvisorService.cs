using Apexa_API.Models;

namespace Apexa_API.Services
{
    public interface IAdvisorService
    {
        List<Advisor> GetAdvisors();
        Advisor GetAdvisorById(int advisorId);
        Advisor UpdateAdvisor(Advisor advisor);
        Advisor CreateAdvisor(Advisor advisor);
        void DeleteAdvisorById(int advisorId);
    }
}
