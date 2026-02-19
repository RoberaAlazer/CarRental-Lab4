using Maintenance.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Maintenance.WebAPI.Controller
{
    [ApiController]
    [Route("api/maintenance")]
    public class MaintenanceController : ControllerBase
    {
        private readonly IRepairHistoryService _service;
        private readonly Dictionary<string, int> _usageCounts;

        public MaintenanceController(
            IRepairHistoryService repairService,
            Dictionary<string, int> usageCounts)
        {
            _service = repairService;
            _usageCounts = usageCounts;
        }

        [HttpGet("crash")]
        public IActionResult Crash()
        {
            int x = 0;
            int y = 5 / x;
            return Ok();
        }

        [HttpGet("usage")]
        public IActionResult Usage()
        {
            var key = Request.Headers["X-Api-Key"].ToString();

            if (!_usageCounts.ContainsKey(key))
                _usageCounts[key] = 0;

            _usageCounts[key]++;

            return Ok(new
            {
                clientId = key,
                callCount = _usageCounts[key]
            });
        }

        [HttpGet("vehicles/{vehicleId}/repairs")]
        public IActionResult GetRepairHistory(int vehicleId)
        {
            var history = _service.GetByVehicleId(vehicleId);
            return Ok(history);
        }
    }
}
