using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Pelebox.API.Models;
using Pelebox.Application.UseCases;
using Pelebox.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pelebox.API.Controllers {
    [Route("[controller]/[action]")]
    [ApiController]
    public class JobController : ControllerBase {

        private readonly JobService _jobService;
        private readonly ILogger<UserController> _logger;

        public JobController(JobService jobService, ILogger<UserController> logger) {
            _jobService = jobService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs() {
            try {
                var jobs = await _jobService.GetJobs(); //get all the jobs with their category
                if (jobs == null) {
                    _logger.LogError("No jobs were found!");
                    return Ok(new { Message = "No available jobs right now!" });
                }
                return Ok(jobs);
            } catch (System.Exception ex) {
                _logger.LogError(ex.Message + "," + ex.InnerException?.Message);
                return Ok(new { Message = ex.Message });
            }
        }

    }
}
