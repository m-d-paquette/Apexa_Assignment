using Apexa_API.Models;
using Apexa_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Apexa_API.Controllers
{
    [ApiController]
    [Route("api/Advisors")]
    public class AdvisorController : ControllerBase
    {
        private readonly ILogger<AdvisorController> _logger;
        private readonly IAdvisorService _advisorService;

        public AdvisorController(IAdvisorService advisorService, ILogger<AdvisorController> logger)
        {
            _advisorService = advisorService;
            _logger = logger;
        }

        [HttpGet(Name = "GetAdvisors")]
        public ActionResult<List<Advisor>> GetAllAdvisors()
        {
            var result = _advisorService.GetAdvisors();
            return Ok(result);
        }

        [HttpGet("{advisorId:int}", Name = "GetAdvisor")]
        public ActionResult<Advisor> GetAdvisorById(int advisorId)
        {
            var result = _advisorService.GetAdvisorById(advisorId);
            return Ok(result);
        }

        [HttpPost(Name = "CreateAdvisor")]
        public ActionResult<Advisor> CreateAdvisor([FromBody] Advisor advisor)
        {
            var result = _advisorService.CreateAdvisor(advisor);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateAdvisor")]
        public ActionResult<Advisor> UpdateAdvisor([FromBody] Advisor advisor)
        {
            var result = _advisorService.UpdateAdvisor(advisor);
            return Ok(result);
        }

        [HttpDelete("{advisorId:int}/Delete", Name = "DeleteAdvisor")]
        public ActionResult DeleteAdvisor(int advisorId)
        {
            _advisorService.DeleteAdvisorById(advisorId);
            return Ok();
        }
    }
}
