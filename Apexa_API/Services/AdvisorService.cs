using Apexa_API.Models;

namespace Apexa_API.Services
{
    public class AdvisorService
    {
        public List<Advisor> GetAdvisors()
        {
            var advisors = new List<Advisor>();
            // get all advisors from the db
            return advisors;
        }
        public Advisor GetAdvisorById(int advisorId)
        {
            var advisor = new Advisor();
            // get advisor from the db
            return advisor;
        }
        public Advisor UpdateAdvisor(Advisor advisor)
        {
            // get advisor from the db
            return advisor;
        }
        public Advisor CreateAdvisor(Advisor advisor)
        {
            // get advisor from the db
            return advisor;
        }
        public void DeleteAdvisorById(int advisorId)
        {
            var advisor = new Advisor();
            // get advisor from the db
            return;
        }
    }
}
