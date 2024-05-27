using Domain_Layer.Interfaces;
using Domain_Layer.Entities;
using Domain_Layer.Enums;
using Infrastructure_Layer.Caching;
using Application_Layer.Interfaces;

namespace Application_Layer.Services
{
    public class AdvisorService : IAdvisorService
    {
        private IAdvisorRepository _repository;
        private readonly MruCache<int, Advisor> _cache;

        public AdvisorService(IAdvisorRepository repository, MruCache<int, Advisor> cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public List<Advisor> GetAdvisors()
        {
            // get all active advisors from the db
            var advisors = _repository.GetActiveAdvisors();
            return advisors;
        }
        public Advisor GetAdvisorById(int advisorId)
        {
            Advisor advisor = _cache.Get(advisorId);
            if (advisor == null)
            {
                // get advisor from the db
                advisor = _repository.GetAdvisorById(advisorId);
                // save to cache
                _cache.Put(advisorId, advisor); 
            }
            return advisor;
        }
        public Advisor UpdateAdvisor(Advisor advisor)
        {
            advisor.UpdatedAt = DateTime.Now;
            // save changes to the db
            _repository.UpdateAdvisor(advisor);
            // update cache
            _cache.Put(advisor.Id, advisor);
            return advisor;
        }
        public Advisor CreateAdvisor(Advisor advisor)
        {
            // get health status
            Random rnd = new Random();
            int statusNumber = rnd.Next(1, 11);

            if (statusNumber < 7)
            {
                // 60% chance of being green
                advisor.HealthStatus = HealthStatus.Green;
            }
            else if (statusNumber < 9)
            {
                // 20% chance of being yellow
                advisor.HealthStatus = HealthStatus.Yellow;
            }
            else
            {
                // 20% chance of being red
                advisor.HealthStatus = HealthStatus.Red;
            }

            advisor.IsActive = true;
            advisor.CreatedAt = DateTime.Now;
            advisor.UpdatedAt = DateTime.Now;
            // save changes to the db
            advisor = _repository.CreateAdvisor(advisor);
            // save to cache
            _cache.Put(advisor.Id, advisor);
            return advisor;
        }
        public void DeleteAdvisorById(int advisorId)
        {
            // delete from the db
            _repository.DeleteAdvisorById(advisorId);
            // delete from cache
            _cache.Delete(advisorId);
            return;
        }
    }
}
