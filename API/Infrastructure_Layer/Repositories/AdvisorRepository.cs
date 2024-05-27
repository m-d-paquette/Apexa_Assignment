using Infrastructure_Layer.Data;
using Domain_Layer.Entities;
using Domain_Layer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using Domain_Layer.Enums;

namespace Infrastructure_Layer.Repositories
{
    public class AdvisorRepository : IAdvisorRepository
    {
        private readonly DatabaseContext _dbContext;
        private bool _disposed = false;
        public AdvisorRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Advisor> GetActiveAdvisors()
        {
            var advisors = _dbContext.Advisors
                .Where(a => a.IsActive)
                .OrderBy(a => a.Name)
                .ToList();
            return advisors;
        }
        public Advisor GetAdvisorById(int advisorId)
        {
            var advisor = _dbContext.Advisors.FirstOrDefault(a => a.Id == advisorId);
            return advisor;
        }
        public void UpdateAdvisor(Advisor advisor)
        {
            try
            {
                _dbContext.Update(advisor);

                _dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("An error occurred while saving changes to the database: " + ex.Message);
            }
        }
        public Advisor CreateAdvisor(Advisor advisor)
        {
            try
            {
                _dbContext.Add(advisor);

                _dbContext.SaveChanges();
                return advisor;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("An error occurred while saving changes to the database: " + ex.Message);
                return advisor;
            }
        }
        public void DeleteAdvisorById(int advisorId)
        {
            var advisor = _dbContext.Advisors.Find(advisorId);
            if (advisor != null) {
                _dbContext.Remove(advisor);
                _dbContext.SaveChanges();
            }
            return;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
