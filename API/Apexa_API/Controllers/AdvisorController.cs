using Domain_Layer.Entities;
using Application_Layer.Interfaces;
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
        public ActionResult GetAllAdvisors()
        {
            var result = _advisorService.GetAdvisors();
            return Ok(result);
        }

        [HttpGet("{advisorId:int}", Name = "GetAdvisor")]
        public ActionResult GetAdvisorById(int advisorId)
        {
            var result = _advisorService.GetAdvisorById(advisorId);
            return Ok(result);
        }

        [HttpPost(Name = "CreateAdvisor")]
        public ActionResult CreateAdvisor([FromBody] Advisor advisor)
        {
            var result = _advisorService.CreateAdvisor(advisor);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateAdvisor")]
        public ActionResult UpdateAdvisor([FromBody] Advisor advisor)
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
