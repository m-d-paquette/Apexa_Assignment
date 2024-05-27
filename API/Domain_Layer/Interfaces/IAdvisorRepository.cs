using Domain_Layer.Entities;

namespace Domain_Layer.Interfaces
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
