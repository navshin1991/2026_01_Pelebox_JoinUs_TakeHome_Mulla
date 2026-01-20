using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Pelebox.Application.Models;
using Pelebox.Application.UseCases;
using Pelebox.Application.ViewModels;
using System.Diagnostics;

namespace Pelebox.API.Controllers {

    [Route("[controller]/[action]")]
    [ApiController]
    public class ApplicationController : ControllerBase {


        private readonly ApplicationService _applicationService;
        private readonly ILogger<UserController> _logger;

        public ApplicationController(ApplicationService applicationService, ILogger<UserController> logger) {
            _applicationService = applicationService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitJobApplication([FromBody] ApplicationSubmitModel appl) {
            try {
                //var result = await _applicationService.Add(appl);

                //if (result != null) {
                //    return Ok(result);
                //}
                return BadRequest("Unable to save the application data.");
            } catch (Exception ex) {
                _logger.LogError(ex.Message + "," + ex.InnerException?.Message);
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
