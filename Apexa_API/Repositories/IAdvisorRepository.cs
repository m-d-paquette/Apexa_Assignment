using Apexa_API.Models;

namespace Apexa_API.Repositories
{
    public interface IAdvisorRepository
    {
        List<Advisor> GetActiveAdvisors();
        Advisor GetAdvisorById(int advisorId);
        void UpdateAdvisor(Advisor advisor);
        Advisor CreateAdvisor(Advisor advisor);
        void DeleteAdvisorById(int advisorId);
    }
}
