using Domain_Layer.Entities;

namespace Application_Layer.Interfaces
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
