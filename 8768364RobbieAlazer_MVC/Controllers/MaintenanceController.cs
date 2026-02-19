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

        public async Task<IActionResult> Usage()
        {
            var client = _httpClientFactory.CreateClient("MaintenanceApi");
            var result = await client.GetFromJsonAsync<object>("api/maintenance/usage");
            return View(result);
        }

        public async Task<IActionResult> Transfer(int fromId, int toId, decimal amount)
        {
            var client = _httpClientFactory.CreateClient("MaintenanceApi");

            var response = await client.PostAsync(
                $"api/RepairHistory/transfer?fromId={fromId}&toId={toId}&amount={amount}",
                null);

            var content = await response.Content.ReadAsStringAsync();

            ViewBag.Result = content;
            return View();
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
