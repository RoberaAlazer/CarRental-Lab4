using _8768364RobbieAlazer_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace _8768364RobbieAlazer_MVC.Controllers
{
    public class MaintenanceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MaintenanceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult History()
        {
            return View(new RepairHistoryPageViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> History(int vehicleId)
        {
            var client = _httpClientFactory.CreateClient("MaintenanceApi");

            var repairs = await client.GetFromJsonAsync<List<RepairHistoryViewModel>>(
                $"api/maintenance/vehicles/{vehicleId}/repairs");

            return View(new RepairHistoryPageViewModel
            {
                VehicleId = vehicleId,
                Repairs = repairs ?? new List<RepairHistoryViewModel>()
            });
        }
    }
}
