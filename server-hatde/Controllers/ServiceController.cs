using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_hatde.Entities;
using server_hatde.Services;

namespace server_hatde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetServicesAsync()
        {
            var services = await _serviceService.GetServicesAsync();
            return Ok(services);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceByIdAsync(int id)
        {
            var service = await _serviceService.GetServiceByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddServiceAsync([FromBody] Service service)
        {
            await _serviceService.AddServiceAsync(service);
            return Ok(service);
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateServiceAsync([FromBody] Service service)
        {
            await _serviceService.UpdateServiceAsync(service);
            return Ok(service);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteServiceAsync(int id)
        {
            await _serviceService.RemoveServiceAsync(id);
            return Ok();
        }
    }
}
